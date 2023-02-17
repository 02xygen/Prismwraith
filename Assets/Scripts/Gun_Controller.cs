using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Controller : MonoBehaviour
{
    public Animator gunAnim;
    public Renderer coreRenderer;
    public Light coreLight;
    public Color storedColor = Color.white;
    public Material storedMat;
    private Color brown = new Color(123, 64, 0, 255);
    private Color orange = new Color(255, 133, 0, 255);
    public LayerMask canvasLayer;
    public Material[] colors;
  
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
        if (hitinfo.collider != null)
        {
            Material targetMat = hitinfo.collider.gameObject.GetComponent<Renderer>().material;
            int mixedColor = ColorComparer(Colorindexer(storedMat), Colorindexer(targetMat));
            if (mixedColor != 0)
                hitinfo.collider.gameObject.GetComponent<Renderer>().material = colors[mixedColor];
        }
    }

    void Siphon()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitinfo, 100, canvasLayer);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.gameObject.GetComponent<Renderer>().material != colors[1])
            {
                storedColor = hitinfo.collider.gameObject.GetComponent<Renderer>().material.color;
                storedMat = hitinfo.collider.gameObject.GetComponent<Renderer>().material;
                coreRenderer.material.SetColor("_Color", storedColor);
                coreRenderer.material.SetColor("_EmissionColor", storedColor * 25);
                coreLight.color = storedColor;
                Debug.Log(Colorindexer(storedMat));
            }
        }
    }

    void Eject()
    {
        coreRenderer.material.SetColor("_Color", Color.white);
        coreRenderer.material.SetColor("_EmissionColor", Color.white);
        coreLight.color = Color.white;
        storedMat = colors[1];

    }

    public int Colorindexer(Material mat)
    {
        for (int i = 1; i < colors.Length; i++)
        {
            if (mat.color == colors[i].color)
                return i;
        }
        return 0;
    }

    public int ColorComparer(int color1, int color2)
    {
        switch (color1)
        {
            case 1:
                return color1;
            case 2:
                if (color2 == 1)
                    return color1;
                if (color2 != 5 && color2 != 6)
                    return color1 + color2;
                break;
            case 3:
                if (color2 == 1)
                    return color1;
                if (color2 != 5 && color2 != 7)
                    return color1 + color2;
                break;
            case 4:
                if (color2 == 1)
                    return color1;
                if (color2 != 6 && color2 != 7)
                    return color1 + color2;
                break;
            case 5:
                if (color2 == 1)
                    return color1;
                if (color2 != 2 && color2 != 3)
                    return color1 + color2;
                break;
            case 6:
                if (color2 == 1)
                    return color1;
                if (color2 != 2 && color2 != 4)
                    return color1 + color2;
                break;
            case 7:
                if (color2 == 1)
                    return color1;
                if (color2 != 3 && color2 != 4)
                    return color1 + color2;
                break;

        }
        return 0;
    }
}
