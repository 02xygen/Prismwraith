using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Controller : MonoBehaviour
{
    public Animator gunAnim;
    public Transform gunTrans;
    public Renderer coreRenderer;
    public Light coreLight;
    public GameObject laser;
    public ParticleSystem laserTrail;
    public Color storedColor = Color.white;
    public Material storedMat;
    public LayerMask canvasLayer;
    public GameObject colorManager;
  
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gunAnim.SetTrigger("Shoot");
            Shoot();
        }
            
    }
    public void OnSiphon(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gunAnim.SetTrigger("Siphon");
            Siphon();
        }
            
    }
    public void OnEject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gunAnim.SetTrigger("Eject");
            Eject();
        }
            
    }

    void Shoot()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitinfo, 100, canvasLayer);
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitpoint, 100);
        if (hitinfo.collider != null)
        {
            laser.transform.LookAt(hitpoint.point);
            laser.GetComponent<ParticleSystem>().Play();
            Material targetMat = hitinfo.collider.gameObject.GetComponent<Renderer>().material;
            int mixedColor = colorManager.GetComponent<ColorMaterialManager>().ColorComparer(colorManager.GetComponent<ColorMaterialManager>().Colorindexer(storedMat), colorManager.GetComponent<ColorMaterialManager>().Colorindexer(targetMat));
            if (mixedColor != 0)
            {
               // = colorManager.GetComponent<ColorMaterialManager>().colors[mixedColor].GetColor("_NewColor");
                hitinfo.collider.GetComponent<Paint>().ChangeColor(mixedColor);
            }
        }

        if (hitpoint.collider != null)
            laser.transform.LookAt(hitpoint.point);
        else
            laser.transform.rotation = gunTrans.rotation;
        
        laser.GetComponent<ParticleSystem>().Play();
    }

    void Siphon()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitinfo, 100, canvasLayer);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.gameObject.GetComponent<Renderer>().material != colorManager.GetComponent<ColorMaterialManager>().colors[1])
            {
                storedColor = hitinfo.collider.gameObject.GetComponent<Renderer>().material.GetColor("_OldColor");
                storedMat = hitinfo.collider.gameObject.GetComponent<Renderer>().material;
                coreRenderer.material.SetColor("_Color", storedColor);
                coreRenderer.material.SetColor("_EmissionColor", storedColor * 25);
                coreLight.color = storedColor;
                storedColor.a = 255;
            }
        }
        var main = laser.GetComponent<ParticleSystem>().main;
        main.startColor = storedColor;
        var laserMain = laserTrail.main;
        laserMain.startColor = storedColor;
        
    }

    void Eject()
    {
        coreRenderer.material.SetColor("_Color", Color.white);
        coreRenderer.material.SetColor("_EmissionColor", Color.white);
        coreLight.color = Color.white;
        storedMat = colorManager.GetComponent<ColorMaterialManager>().colors[1];
        var main = laser.GetComponent<ParticleSystem>().main;
        main.startColor = Color.white;
        var laserMain = laserTrail.main;
        laserMain.startColor = Color.white;

    }
}
