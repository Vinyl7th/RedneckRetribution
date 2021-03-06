﻿using UnityEngine;
using System.Collections;

public class skeleton : MonoBehaviour
{

    //Gameobjects for the player and a object for the killcounter
    GameObject thePlayer;
    

    [SerializeField]
    AudioSource damageNoise;

    [SerializeField]
    AudioSource attackNoise;

    Animator theAnimator;

    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;
    float healthRegenTimer = 0.0f;

    bool regenHealth;
    bool isRightattack;
    bool isRight;



    //basic varible to hold the skeletons stats
    public float aggroRange,
           moveSpeed,
           maxHealth,
           hitPoints;



    // Use this for initialization
    void Start()
    {


        theAnimator = gameObject.GetComponent<Animator>();


        // At the start make the thePlayer gameobject the player with tag
        thePlayer = GameObject.FindWithTag("Player");

        
        damageNoise.volume = soundController.sfxValue;
        attackNoise.volume = soundController.sfxValue;

        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;

        regenHealth = false;
        // Set the Enemy's Movement Speed, Hitpoints, and aggrorange
        aggroRange = 20.0f;
        moveSpeed = 2.5f;
        hitPoints = 1500.0f;
        maxHealth = hitPoints;

    }

    // Update is called once per frame
    void Update()
    {
        healthRegenTimer += Time.deltaTime;

        if (regenHealth == true && hitPoints < maxHealth)
        {
            if (healthRegenTimer >= 0.5f)
            {
                if (hitPoints < maxHealth)
                    hitPoints += 50;
                if (hitPoints >= maxHealth)
                    hitPoints = maxHealth;

                healthRegenTimer = 0.0f;
            }
        }

        //  if enemy took damage  

        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            Color newColor = new Color(1.0f, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

            //after the color is red change the color back to its normal color
            //and change the bool back to false
            if (delayColorChanger >= 0.1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                delayColorChanger = 0.0f;
                changeColor = false;
            }
        }

        //enemy's movement  
        Move();
        if ((int)gameObject.transform.position.x > (int)thePlayer.transform.position.x)
        {
            if (!isRightattack)
            {
                theAnimator.transform.localScale = new Vector3(-1, 1, 1);
                isRightattack = true;
            }
            else
                isRightattack = false;
        }
        else
        {
            if (!isRightattack)
            {
                theAnimator.transform.localScale = new Vector3(1, 1, 1);
                isRightattack = true;
            }
            else
                isRightattack = false;
        }

        //if the healthpoints are 0 destroy the enemy on screen
        if (hitPoints < 0.0f)
        {
            GetComponent<Drops>().Drop();
            Destroy(gameObject);
        }

    }

    //Function that passes the amount damage the enemy needs to receive
    public void RecieveDamage(float _dmg)
    {
        damageNoise.Play();
        hitPoints -= _dmg;
        changeColor = true;

    }

    //Funtion that makes the enemy move based on the character's position
    void Move()
    {
        //Set the player movement every frame to 0x 0y
        Vector2 moveEnemy = new Vector2(0, 0);

        // tracks the distance to the player's position from the skeleton's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

        //if player's position is with then the range of the skeleton's aggrorange
        if (DisToPlayer <= aggroRange)
        {
            theAnimator.SetBool("Walk", true);
            //temp varibles for the player's and enemies's position
            float playerX = thePlayer.transform.position.x;
            float playerY = thePlayer.transform.position.y;
            float enemyX = gameObject.transform.position.x;
            float enemyY = gameObject.transform.position.y;
            // RayCast Search
            RaycastHit2D hit;
          

            // Ray2D enemySearch = new Ray2D(transform.position, thePlayer.transform.position);
            hit = Physics2D.Raycast(transform.position, thePlayer.transform.position, 3.0f);

            Debug.DrawLine(transform.position, hit.transform.position, Color.green);
            if(hit.collider.gameObject != gameObject && hit.collider.tag != "NecroAura")
            {

                 if (hit.collider.tag != thePlayer.tag && hit.collider.tag != "NecroAura")
                {
                    float aPosX = hit.collider.transform.position.x;
                    
                    float aPosY = hit.collider.transform.position.y;
                    if (aPosX >= enemyX)        // enemy move right
                        moveEnemy.x = -moveSpeed;
                    if (aPosX < enemyX)        // enemy move left
                        moveEnemy.x = moveSpeed;
                    if (aPosY >= enemyY)        // enemy move up
                        moveEnemy.y = -moveSpeed;
                    if (aPosY < enemyY)        // enemy move down
                        moveEnemy.y = moveSpeed;
                }
            }
            else
            {

            //chase player
            if (playerX > enemyX)        // enemy move right
                moveEnemy.x = moveSpeed;
            if (playerX < enemyX)        // enemy move left
                moveEnemy.x = -moveSpeed;
            if (playerY > enemyY)        // enemy move up
                moveEnemy.y = moveSpeed;
            if (playerY < enemyY)        // enemy move down
                moveEnemy.y = -moveSpeed;
            }
        }
        else
        {
            theAnimator.SetBool("Walk", false);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
        if (DisToPlayer <= 2f)
        {
            theAnimator.SetBool("Attack", true);
        }
        else
            theAnimator.SetBool("Attack", false);
    }

    //Checks if the enemy is within range of the necro's aura
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "NecroAura")
        {
            regenHealth = true;
        }

        if (other.gameObject.tag == "Player")
        {
            attackNoise.Play();
            other.SendMessage("TakePhysicalDamage", 50);
        }

    }



    //Check if the enemy leaves the range of the necro's aura
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NecroAura")
            regenHealth = false;
    }



    





}
