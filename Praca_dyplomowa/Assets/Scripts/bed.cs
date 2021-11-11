using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public GameObject target;
    void OnTriggerEnter2D(Collider2D col)
    {

        PlayerMovement.health = PlayerMovement.healthstart;
        print("bed");
    }
    }

