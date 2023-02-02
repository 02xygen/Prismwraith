using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Controller : MonoBehaviour
{
    public Animator gunAnim;
    public void OnShoot(InputAction.CallbackContext context)
    {
        gunAnim.SetTrigger("Shoot");
    }
    public void OnSiphon(InputAction.CallbackContext context)
    {
        gunAnim.SetTrigger("Siphon");
    }
    public void OnEject(InputAction.CallbackContext context)
    {
        gunAnim.SetTrigger("Eject");
    }

}
