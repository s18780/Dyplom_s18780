using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  Healthbar healthBar;
    Animator animator;
    private Rigidbody2D rb;
    public float speed = 5f;
    bool walk_right;
    bool walk_left;
    public GameObject player;
    bool walkup;
    bool walkdown;
    bool walkLeft;
    bool walkright;
    bool attack;

    public static int health=4;
    public static int healthstart;
    public float range = 8f;
    public GameObject enemyA;
    int ea;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        
        walk_right = false;
        walkLeft = false;
        walkright = false;
        attack = false;
       // health = 4;
        healthstart = 4;
       // healthBar.SetSize(1f);


    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float y = transform.position.y + speed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position = new Vector3(x, y, 0f);


        if (Input.GetKey("a"))
        {
            walkLeft = true;
            
        }
        else { walkLeft = false; }
        if (Input.GetKey("d"))
        {
            print("d");
            walkright = true;
        }
        else { walkright = false; }

        if (Input.GetKey("w"))
        {
            walkup = true;
        }
        else { walkup = false; }

        if (Input.GetKey("s"))
        {
            walkdown = true;
        }
        else { walkdown = false; }
        if (walkLeft)
        {
            animator.SetBool("walkleft", true);

        }
        else
        {
            animator.SetBool("walkleft", false);
        }
        if (walkright)
        {
            animator.SetBool("walkright", true);

        }
        else
        {
            animator.SetBool("walkright", false);
        }
        if (walkup)
        {
            animator.SetBool("walkup", true);

        }
        else
        {
            animator.SetBool("walkup", false);
        }
        if (walkdown)
        {
            animator.SetBool("walkdown", true);

        }
        else
        {
            animator.SetBool("walkdown", false);
        }

        if (health == 0)
        {
            SceneManager.LoadScene(1);
            health = healthstart;
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePos - transform.position).normalized; //wektor dlugosci 1
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range);
            //hit.collider.gameObject.CompareTag("enemy")
            if (hit.collider != null && hit.collider.gameObject.CompareTag("enemy"))
            {
                Slime.health-=1;
              
                
                print("Trafienie!");
                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            }
            else
            {
                print("pudło!");
                 // pudło
                Debug.DrawLine(transform.position, transform.position + direction * range, Color.white, 1f);
            }
            
        }

    }
}
