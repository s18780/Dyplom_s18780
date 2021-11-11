using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {

        

    }
    void Update() {
        Transform bar = transform.Find("Bar");
        float b = (float)PlayerMovement.health / (float) PlayerMovement.healthstart;
        

        bar.localScale = new Vector3(b, 1f);
    }
    
}
