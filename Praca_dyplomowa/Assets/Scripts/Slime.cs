using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    Animator animator;
    public float speed = 2f;

    public GameObject target;
    public float moveRange;

    int stop = 1;

    public static int health;
    public static int attack;

    enum State
    {
        PointA,
        PointB,
        PointC,
        Chasing

    }
    private State state = State.PointA;
    //Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();

        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 pointA = new Vector3(2, -1, 0);
        Vector3 pointB = new Vector3(4, -1, 0);
        Vector3 pointC = new Vector3(7, 0, 0);

        Vector3 enemyPos;

        switch (state)
        {
            case State.PointA:
                transform.position = Vector3.MoveTowards(transform.position, pointA, speed * Time.deltaTime);
                enemyPos = transform.position;
                animator.SetBool("walk", true);
                if (enemyPos == pointA)
                {
                    state = State.PointB;
                   
                }
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < 5)
                {
                    stop = 1;
                    state = State.Chasing;


                }
                break;
            case State.PointB:
                transform.position = Vector3.MoveTowards(transform.position, pointB, speed * Time.deltaTime);
                enemyPos = transform.position;
                distance = Vector3.Distance(transform.position, target.transform.position);
                animator.SetBool("walk", true);
                if (enemyPos == pointB)
                {
                    state = State.PointC;
                    
                }
                if (distance < 5)
                {
                    stop = 2;
                    state = State.Chasing;


                }
                break;
            case State.PointC:
                transform.position = Vector3.MoveTowards(transform.position, pointC, speed * Time.deltaTime);
                enemyPos = transform.position;
                animator.SetBool("walk", true);
                if (enemyPos == pointC)
                {
                    state = State.PointA;
                    print("toa");
                }
                distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < 5)
                {
                    stop = 3;
                    state = State.Chasing;


                }
                break;
            case State.Chasing:
                animator.SetBool("attack", true);
                animator.SetBool("walk", false);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (speed + 1) * Time.deltaTime);

                enemyPos = transform.position;
                float distance2 = Vector3.Distance(transform.position, target.transform.position);
                if (distance2 > 5)
                {
                    switch (stop)
                    {
                        case 1:
                            state = State.PointA;
                            break;
                        case 2:
                            state = State.PointB;
                            break;
                        case 3:
                            state = State.PointC;
                            break;
                    }

                }
                
                break;
                animator.SetBool("attack", false);

        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    void spawn()
    {
        Vector3 v = new Vector3(9, 6, 0);

        float distance2 = Vector3.Distance(transform.position, target.transform.position);
        if (distance2 == 0)
        {
            target.transform.position = v;
            
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
       
        PlayerMovement.health -= 1;

    }
}
