using UnityEngine;
using System.Collections;

public class Necromancer : MonoBehaviour
{

    public GameObject FireBall;

    //Gameobjects for the player and a object for the killcounter
    GameObject thePlayer,
               killcounter;

    [SerializeField]
    AudioSource hitSound;
    [SerializeField]
    AudioSource fireballSound;
    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;

    //bool to switch when the necro fireball cast is on cooldown
    bool offCoolDown;


    //basic varible to hold the Necromancer's stats
    public float aggroRange,
           runAway,
           moveSpeed,
           maxHealth,
           hitPoints,
           fireDelay,
           delayCastFireball;
    int count = 0;


    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
        fireballSound.volume = hitSound.volume = soundController.sfxValue;
        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
        hitSound.volume *= 2;
        //have offcooldown set to true so he fires at the beginning
        offCoolDown = true;



        // Set the Enemy's Movement Speed, Hitpoints, aggrorange,
        //when to runaway, and when cast fireballs
        aggroRange = 30.0f;
        moveSpeed = 4.5f;
        hitPoints = 2000.0f;
        runAway = 5;
        maxHealth = hitPoints;


    }

    public void RecieveDamage(float _dmg)
    {
        hitSound.Play();
        hitPoints -= _dmg;
        changeColor = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (!offCoolDown)
            delayCastFireball += Time.deltaTime;


        //  if enemy took damage  
        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0, 0);

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

        //if the healthpoints are 0 destroy the enemy on screen
        if (hitPoints < 0.0f)
        {
            Destroy(gameObject);
        }

    }

    void Move()
    {

        //Set the player movement every frame to 0x 0y
        Vector2 moveEnemy = new Vector2(0, 0);

        // tracks the distance to the player's position from the Enemy's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

        //if player's position is with then the range of the Enemy's aggrorange
        if (DisToPlayer <= aggroRange)
        {
            //per fireball being shot 
            fireDelay += Time.deltaTime;



            //temp varibles for the player's and enemies's position
            float playerX = thePlayer.transform.position.x;
            float playerY = thePlayer.transform.position.y;
            float enemyX = gameObject.transform.position.x;
            float enemyY = gameObject.transform.position.y;

            // cast a certain amount of fireballs and
            //then have a cooldown to cast the next volley of fireballs
            if (offCoolDown)
            {
                if (fireDelay >= 0.09f)
                {
                    //calling the function to fire the fireball
                    fireballSound.Play();
                    CastFireball();
                    count++;
                    if (count == 8)
                        offCoolDown = false;
                    fireDelay = 0;
                }

            }
            //When on cooldown necromancer can't cast and has to wait for a period of time.
            else
            {
                if (delayCastFireball >= 3.0f)
                {
                    offCoolDown = true;
                    delayCastFireball = 0;
                    count = 0;
                }
            }

            if(DisToPlayer >= 6)
            {
                if (playerX >= enemyX)         // enemy move left
                    moveEnemy.x = moveSpeed;
                if (playerX <= enemyX)         // enemy move right
                    moveEnemy.x = -moveSpeed;
                if (playerY >= enemyY)         // enemy move down
                    moveEnemy.y = moveSpeed;
                if (playerY <= enemyY)         // enemy move up
                    moveEnemy.y = -moveSpeed;
            }
            //Run away from the player
            if (DisToPlayer <= runAway)
            {
                if (playerX >= enemyX)         // enemy move left
                    moveEnemy.x = -moveSpeed;
                if (playerX <= enemyX)         // enemy move right
                    moveEnemy.x = moveSpeed;
                if (playerY >= enemyY)         // enemy move down
                    moveEnemy.y = -moveSpeed;
                if (playerY <= enemyY)         // enemy move up
                    moveEnemy.y = moveSpeed;
            }
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
    }




    void CastFireball()
    {
        Instantiate(FireBall, gameObject.transform.position, gameObject.transform.rotation);
    }


}


