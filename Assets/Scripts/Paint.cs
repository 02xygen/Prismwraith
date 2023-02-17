using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public GameObject colorManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeColor(int colorIndex)
    { 
        if (colorIndex != 0)
        gameObject.GetComponent<Renderer>().material = colorManager.GetComponent<ColorMaterialManager>().colors[colorIndex];
    }
}
