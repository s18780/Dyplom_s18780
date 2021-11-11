using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tocity : MonoBehaviour
{
    public bool exitActived;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(0);
                print("zmiana");
            }
            else
                SceneManager.LoadScene(2);

           

        }

    }
}
