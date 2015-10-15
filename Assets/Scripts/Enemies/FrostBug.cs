using UnityEngine;
using System.Collections;

public class FrostBug : MonoBehaviour
{
    GameObject thePlayer;

    bool hiding;
    bool charging;
    bool running;
    public Sprite hideSprite;
    public Sprite chargeSprite;
    [SerializeField]
    AudioSource ChargeSound;
    [SerializeField]
    AudioSource HideSound;
    [SerializeField]
    AudioSource HurtSound;
    Animator theAnimator;
    public float maxHealth;
    public float currHealth;
    float tempHealth;
    float distance;
    Vector3 jumpPoint;

    Vector2 moveEnemy = Vector2.zero;
    float moveSpeed = 9;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        theAnimator = GetComponent<Animator>();
        maxHealth = currHealth = 1500;
        ChargeSound.volume = HideSound.volume = HurtSound.volume = soundController.sfxValue;
         jumpPoint = thePlayer.transform.position;
        hiding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
            Destroy(gameObject);
      
        distance = Vector2.Distance(transform.position, jumpPoint);
        if (!hiding)
        {
            jumpPoint = thePlayer.transform.position;
            hiding = false;
        }
        if (hiding)
            Hide();
        if (charging)
            Charge();
       


    }

    public void RecieveDamage(float _dmg)
    {
        if (!HurtSound.isPlaying)
            HurtSound.Play();
        currHealth -= _dmg;
    }
    void Hide()
    {
        GetComponent<SpriteRenderer>().sprite = hideSprite;
        theAnimator.SetBool("walk", false);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        moveEnemy = Vector2.zero;
        moveSpeed = 5;
        if (!HideSound.isPlaying)
            HideSound.Play();
        if (!running)
        {
           
            if (distance >= 1.0f)
            {
                if (jumpPoint.x >= transform.position.x)         // enemy move left
                    moveEnemy.x = moveSpeed;
                if (jumpPoint.x <= transform.position.x)         // enemy move right
                    moveEnemy.x = -moveSpeed;
                if (jumpPoint.y >= transform.position.y)         // enemy move down
                    moveEnemy.y = moveSpeed;
                if (jumpPoint.y <= transform.position.y)         // enemy move up
                    moveEnemy.y = -moveSpeed;
            }
            else
            {
                moveEnemy = Vector2.zero;
                hiding = false;
                theAnimator.SetBool("jump", true);
                HideSound.Stop();
                tempHealth = currHealth;
                charging = true;
            }
        }
        else
        {

            if (distance <= 10)
            {
                if (jumpPoint.x >= transform.position.x)         // enemy move left
                    moveEnemy.x = -moveSpeed;
                if (jumpPoint.x <= transform.position.x)         // enemy move right
                    moveEnemy.x = moveSpeed;
                if (jumpPoint.y >= transform.position.y)         // enemy move down
                    moveEnemy.y = -moveSpeed;
                if (jumpPoint.y <= transform.position.y)         // enemy move up
                    moveEnemy.y = moveSpeed;
            }
            else
                running = false;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
    }
    void Charge()
    {
        GetComponent<SpriteRenderer>().sprite = chargeSprite;
        theAnimator.SetBool("walk", true);
        theAnimator.SetBool("jump", false);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        moveEnemy = Vector2.zero;
        moveSpeed = 10;
        if (!ChargeSound.isPlaying)
            ChargeSound.Play();
        if (distance >= 1.0f)
        {
            if ((int)jumpPoint.x >= (int)transform.position.x)         // enemy move left
                moveEnemy.x = moveSpeed;
            if ((int)jumpPoint.x <= (int)transform.position.x)         // enemy move right
                moveEnemy.x = -moveSpeed;
            if ((int)jumpPoint.y >= (int)transform.position.y)         // enemy move down
                moveEnemy.y = moveSpeed;
            if ((int)jumpPoint.y <= (int)transform.position.y)         // enemy move up
                moveEnemy.y = -moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
        if (currHealth <= tempHealth - tempHealth * 0.1f)
        {
            running = true;
            hiding = true;
            charging = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            charging = false;
            hiding = true;
            running = true;

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            other.SendMessage("TakePhysicalDamage", 50);
            thePlayer.SendMessage("Slow");
        }
    }
}
