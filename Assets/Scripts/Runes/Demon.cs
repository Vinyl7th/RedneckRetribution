using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour
{
    public GameObject demonShot;
    float moveSpeed = 10;
   public Vector2 moveVelocity;
    float fireRate = 0.0f;
    float deathTimer = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireRate += Time.deltaTime;
        deathTimer += Time.deltaTime;
        if(deathTimer >= 30.0f)
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("Change");
            Destroy(gameObject);
        }
        moveVelocity = new Vector2(0, 0);
        if (Input.GetButton("MoveUp"))
        {
            moveVelocity.y = moveSpeed;
            //theAnimator.SetBool("walkRight", true);
        }
        if (Input.GetButton("MoveDown"))
        {
            moveVelocity.y = -moveSpeed;
           // theAnimator.SetBool("walkRight", true);
        }
        if (Input.GetButton("MoveLeft"))
        {
            moveVelocity.x = -moveSpeed;
          //  theAnimator.transform.localScale = new Vector3(-1, 1, 1);
           // theAnimator.SetBool("walkRight", true);

        }
        if (Input.GetButton("MoveRight"))
        {
            moveVelocity.x = moveSpeed;
          //  theAnimator.transform.localScale = new Vector3(1, 1, 1);
           // theAnimator.SetBool("walkRight", true);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVelocity;
        if (Input.GetButton("Fire1"))
        {
            ShootEnergy();
        }
    }

    void ShootEnergy()
    {
        if (fireRate >= 0.25f)
        { 
            Instantiate(demonShot, gameObject.transform.position, gameObject.transform.rotation);
            fireRate = 0;
        }
    }
}

