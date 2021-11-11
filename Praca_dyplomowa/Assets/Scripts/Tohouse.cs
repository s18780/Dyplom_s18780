using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tohouse : MonoBehaviour
{

    public bool exitActived;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            int zdrowie =PlayerMovement.health;
            print("zdrowie przed: " + zdrowie);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
                PlayerMovement.health = zdrowie;
                print("po "+PlayerMovement.health);
            }
            else
                SceneManager.LoadScene(0);


        }
    }
}