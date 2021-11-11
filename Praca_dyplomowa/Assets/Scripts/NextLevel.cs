using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public bool exitActived;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(3);
                
            }
            else
                SceneManager.LoadScene(3);



        }

    }
}
