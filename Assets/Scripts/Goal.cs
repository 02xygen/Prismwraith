using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    public Text text;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            text.gameObject.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(closeGame());
        }
    }

    IEnumerator closeGame()
    {
        yield return new WaitForSecondsRealtime(5);
        Application.Quit();
    }
}
