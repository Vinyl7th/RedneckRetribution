using UnityEngine;
using System.Collections;

public class Witch : MonoBehaviour {
    public GameObject FireBall;

    [SerializeField]
    AudioSource teleportNoise;
    [SerializeField]
    AudioSource fireballSound;

    Vector3 theCameraPlusPos;
    
   
    //Gameobjects for the player and a object for the killcounter
    GameObject thePlayer;

    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;

    //bool to switch when the necro fireball cast is on cooldown
    bool offCoolDown;

    bool regenHealth;
    float healthRegenTimer = 0.0f;


        float timersp;


    //basic varible to hold the Necromancer's stats
    public float aggroRange,
           moveSpeed,
           runAway,
           maxHealth,
           hitPoints,
           fireDelay,
           delayCastFireball;
    int count = 0;


    // Use this for initialization
    void Start()
    {

        theCameraPlusPos = Camera.main.transform.position;
        theCameraPlusPos.z = transform.position.z;
        thePlayer = GameObject.FindWithTag("Player");

        teleportNoise.volume = fireballSound.volume = soundController.sfxValue;

        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;

        //have offcooldown set to true so he fires at the beginning
        offCoolDown = true;

        regenHealth = false;



        // Set the Enemy's Movement Speed, Hitpoints, aggrorange,
        //when to runaway, and when cast fireballs
        aggroRange = 30.0f;
        moveSpeed = 3f;
        runAway = 2.5f;
        hitPoints = 2500.0f;
        maxHealth = hitPoints;

      


    }

    public void RecieveDamage(float _dmg)
    {
        teleportNoise.Play();
        hitPoints -= _dmg;
        changeColor = true;

    }

    // Update is called once per frame
    void Update()
    {
        timersp += Time.deltaTime;

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
            teleportNoise.PlayOneShot(teleportNoise.clip, teleportNoise.volume);
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

        //temp varibles for the player's and enemies's position
        float playerX = thePlayer.transform.position.x;
        float playerY = thePlayer.transform.position.y;
        float enemyX = gameObject.transform.position.x;
        float enemyY = gameObject.transform.position.y;

        //if player's position is with then the range of the Enemy's aggrorange
        if (DisToPlayer <= aggroRange)
        {
            //per fireball being shot 
            fireDelay += Time.deltaTime;



            // cast a certain amount of fireballs and
            //then have a cooldown to cast the next volley of fireballs
            if (offCoolDown)
            {
                if (fireDelay >= 0.5f)
                {
                    //calling the function to fire the fireball
                    fireballSound.Play();
                    CastFireball();
                    count++;
                    if (count == 4)
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

            if (timersp >= 3.0f)
            {
                float X_num = Random.Range(-14, 14);
                float Y_Num = Random.Range(-8, 8);
                theCameraPlusPos = Camera.main.transform.position;
                theCameraPlusPos.z = transform.position.z;
                theCameraPlusPos.x = theCameraPlusPos.x + X_num;
                theCameraPlusPos.y = theCameraPlusPos.y + Y_Num;


                transform.position = theCameraPlusPos;
                timersp = 0;
            }

            if (DisToPlayer <= runAway)
            {
                float X_num = Random.Range(-14, 14);
                float Y_Num = Random.Range(-8, 8);
                theCameraPlusPos = Camera.main.transform.position;
                theCameraPlusPos.z = transform.position.z;
                theCameraPlusPos.x = theCameraPlusPos.x + X_num;
                theCameraPlusPos.y = theCameraPlusPos.y + Y_Num;


                transform.position = theCameraPlusPos;
                timersp = 0;
            }

        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "NecroAura")
        {
            regenHealth = true;
        }
    }

    void CastFireball()
    {
        Instantiate(FireBall, gameObject.transform.position, gameObject.transform.rotation);
    }


    //Check if the enemy leaves the range of the necro's aura
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NecroAura")
            regenHealth = false;
    }

}
