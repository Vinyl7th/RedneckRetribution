using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour
{
    public GameObject demonShot;
    float moveSpeed = 10;
   public Vector2 moveVelocity;
    float fireRate = 0.0f;
    float deathTimer = 0.0f;
    Animator theAnimator;
    GameObject reticule;
    // Use this for initialization
    void Start()
    {
        theAnimator = GetComponent<Animator>();
        reticule = GameObject.FindGameObjectWithTag("Reticule");
    }

    // Update is called once per frame
    void Update()
    {
        fireRate += Time.deltaTime;
        deathTimer += Time.deltaTime;
       
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        if(deathTimer >= 30.0f)
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("Change");
            Destroy(gameObject);
        }
        moveVelocity = new Vector2(0, 0);
        if (Input.GetButton("MoveUp"))
        {
            moveVelocity.y = moveSpeed;
            theAnimator.SetBool("move", true);
            //theAnimator.SetBool("walkRight", true);
        }
        
        if (Input.GetButton("MoveDown"))
        {
            moveVelocity.y = -moveSpeed;
            theAnimator.SetBool("move", true);
            // theAnimator.SetBool("walkRight", true);
        }
       
        if (Input.GetButton("MoveLeft"))
        {
            moveVelocity.x = -moveSpeed;
            theAnimator.SetBool("move", true);
           // theAnimator.transform.localScale = new Vector3(1, 1, 1);
            // theAnimator.SetBool("walkRight", true);

        }
        
        if (Input.GetButton("MoveRight"))
        {
            moveVelocity.x = moveSpeed;
            theAnimator.SetBool("move", true);
             // theAnimator.transform.localScale = new Vector3(-1, 1, 1);
            // theAnimator.SetBool("walkRight", true);
        }

        if (reticule.transform.position.x >= transform.position.x)
            theAnimator.transform.localScale = new Vector3(-1, 1, 1);
        else
            theAnimator.transform.localScale = new Vector3(1, 1, 1);
        
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVelocity;
        if (Input.GetButton("Fire1"))
        {
             
            theAnimator.SetBool("move", false);
            ShootEnergy();
        }
        else
            theAnimator.SetBool("attack", false);
    }

    void ShootEnergy()
    {
        if (fireRate >= 0.25f)
        {
            theAnimator.SetBool("move", false);
            theAnimator.SetBool("attack", true);
            Instantiate(demonShot, gameObject.transform.position, gameObject.transform.rotation);
            fireRate = 0;
        }
    }
}

