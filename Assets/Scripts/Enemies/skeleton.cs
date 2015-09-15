using UnityEngine;
using System.Collections;

public class skeleton : MonoBehaviour {

    GameObject thePlayer,
               spawnCounter;


    Color baseColor;
    bool changeColor;
    float delayColorChanger;

    float aggroRange,
           moveSpeed,
           hitPoints;

    // Use this for initialization
    void Start()
    {
        // At the start make the thePlayer gameobject the player with tag
        thePlayer = GameObject.FindWithTag("Player");

        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;

        // Set the Enemy's Movement Speed, Hitpoints, and aggrorange
        aggroRange = 10.0f;
        moveSpeed = 4.2f;
        hitPoints = 2000.0f;

    }

    // Update is called once per frame
    void Update()
    {

        //  if enemy took damage  

        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);

            //after the color is red change the color back to its normal color
            //and change the bool back to false
            if (delayColorChanger >= 0.5f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                delayColorChanger = 0.0f;
                changeColor = false;
            }
        }

        //enemy's movement  
        Move();

        //if the healthpoints are 0 destroy the enemy on screen
        if (hitPoints < 0.0f)
        {
            Destroy(gameObject);
        }

    }

    //Function that passes the amount damage the enemy needs to receive
    public void receiveDamage(float _dmg)
    {
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
            //temp varibles for the player's and enemies's position
            float playerX = thePlayer.transform.position.x;
            float playerY = thePlayer.transform.position.y;
            float enemyX = gameObject.transform.position.x;
            float enemyY = gameObject.transform.position.y;

            if (playerX > enemyX)        // enemy move right
                moveEnemy.x += moveSpeed;
            if (playerX < enemyX)        // enemy move left
                moveEnemy.x -= moveSpeed;
            if (playerY > enemyY)        // enemy move up
                moveEnemy.y += moveSpeed;
            if (playerY < enemyY)        // enemy move down
                moveEnemy.y -= moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
    }

}
