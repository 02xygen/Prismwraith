using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Controller : MonoBehaviour
{
    public Animator gunAnim;
    public Renderer coreRenderer;
    public Light coreLight;
    public Color storedColor;
    public LayerMask canvasLayer;
    
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
            Debug.Log("SHOT");
            int newColorNumber = ColorComparer(storedColor, hitinfo.collider.gameObject.GetComponent<Renderer>().material.color);
            hitinfo.collider.gameObject.GetComponent<Renderer>().material.color = ColorUnNumberer(newColorNumber);
        }
    }

    void Siphon()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitinfo, 100, canvasLayer);
        if (hitinfo.collider != null)
        {
            storedColor = hitinfo.collider.gameObject.GetComponent<Renderer>().material.color;
            coreRenderer.material.color = storedColor;
            coreRenderer.material.SetColor("_EmissionColor", storedColor * 50f);
            coreLight.color = storedColor;
        }
    }

    void Eject()
    {
        coreRenderer.material.SetColor("_Color", Color.white);
        coreRenderer.material.SetColor("_EmissionColor", Color.white * 25f);
        storedColor = Color.white;
        coreLight.color = Color.white;
    }

    int ColorNumberer(Color color)
    {
        if (color == Color.white)
            return 1;
        else if (color == Color.red)
            return 2;
        else if (color == Color.blue)
            return 3;
        else if (color == Color.yellow)
            return 4;
        else if (color == Color.magenta)
            return 5;
        else if (color == new Color(255, 238, 0, 255))
            return 6;
        else if (color == Color.green)
            return 7;
        else
            return 9;
    }

    Color ColorUnNumberer(int num)
    {
        if (num == 1)
            return Color.white;
        else if (num == 2)
            return Color.red;
        else if (num == 3)
            return Color.blue;
        else if (num == 4)
            return Color.yellow;
        else if (num == 5)
            return Color.magenta;
        else if (num == 6)
            return new Color(255, 238, 0, 255);
        else if (num == 7)
            return Color.green;
        else
            return new Color(133, 78, 0, 255);
    }

    int ColorComparer(Color storedColor, Color baseColor)
    {
        int baseColorNumber = ColorNumberer(baseColor);
        int storedColorNumber = ColorNumberer(storedColor);

        switch (baseColorNumber)
        {
            case 1:
                return storedColorNumber; 
            case 2:
                if (storedColorNumber != 5 || storedColorNumber != 6)
                    return storedColorNumber + baseColorNumber;
                break;
            case 3:
                if (storedColorNumber != 5 || storedColorNumber != 7)
                    return storedColorNumber + baseColorNumber;
                break;
            case 4:
                if (storedColorNumber != 6 || storedColorNumber != 7)
                    return storedColorNumber + baseColorNumber;
                break;
            case 5:
                if (storedColorNumber != 2 || storedColorNumber != 3)
                    return storedColorNumber + baseColorNumber;
                break;
            case 6:
                if (storedColorNumber != 2 || storedColorNumber != 4)
                    return storedColorNumber + baseColorNumber;
                break;
            case 7:
                if (storedColorNumber != 3 || storedColorNumber != 4)
                    return storedColorNumber + baseColorNumber;
                break;
     
        }
        return 0;

    }
}
