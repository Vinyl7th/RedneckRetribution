using UnityEngine;
using System.Collections;

public class MotherSpider : MonoBehaviour {


    public GameObject SpiderWeb, BabySpider;
    GameObject spiderspawn;

   public Transform[] SummonSpider; 

    //Gameobjects for the player and a object for the killcounter
    GameObject thePlayer,
               killcounter;

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
           delayCastSpiderWeb;
    int count = 0;



    // Use this for initialization
    void Start () {
        thePlayer = GameObject.FindWithTag("Player");

        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;

        //have offcooldown set to true so he fires at the beginning
        offCoolDown = true;
        SummonSpider = new Transform[5];


        // Set the Enemy's Movement Speed, Hitpoints, aggrorange,
        //when to runaway, and when cast fireballs
        aggroRange = 20.0f;
        moveSpeed = 3f;
        hitPoints = 5000.0f;
        runAway = 5;
        maxHealth = hitPoints;

    }
	
	// Update is called once per frame
	void Update () {

        if (!offCoolDown)
            delayCastSpiderWeb += Time.deltaTime;


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
        if (hitPoints <= 2500.0f)
        {
            SummonSpiderpoint();
            Destroy(gameObject);
        }

    }

    public void RecieveDamage(float _dmg)
    {
        hitPoints -= _dmg;
        changeColor = true;

    }

    void Move()
    {

        // tracks the distance to the player's position from the Enemy's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

        //if player's position is with then the range of the Enemy's aggrorange
        if (DisToPlayer <= aggroRange)
        {
            //per fireball being shot 
            fireDelay += Time.deltaTime;
            // cast a certain amount of fireballs and
            //then have a cooldown to cast the next volley of fireballs
            if (offCoolDown)
            {
                if (fireDelay >= 0.09f)
                {
                    //calling the function to fire the fireball
                    CastSpiderWeb();
                    count++;
                    if (count == 4)
                        offCoolDown = false;
                    fireDelay = 0;
                }

            }
            //When on cooldown necromancer can't cast and has to wait for a period of time.
            else
            {
                if (delayCastSpiderWeb >= 3.0f)
                {
                    offCoolDown = true;
                    delayCastSpiderWeb = 0;
                    count = 0;
                }
            }
        }
    }

    void CastSpiderWeb()
    {
        Instantiate(SpiderWeb, gameObject.transform.position, gameObject.transform.rotation);
    }


    void SummonSpiderpoint()
    {

        for (int i = 0; i < 20; i++)
        {
            int _num = Random.Range(0, 4);
            switch (_num)
            {
                case 0:
                    Instantiate(BabySpider, SummonSpider[0].transform.position, gameObject.transform.rotation);
                    break;
                case 1:
                    Instantiate(BabySpider, SummonSpider[1].transform.position, gameObject.transform.rotation);
                    break;
                case 2:
                    Instantiate(BabySpider, SummonSpider[2].transform.position, gameObject.transform.rotation);
                    break;
                case 3:
                    Instantiate(BabySpider, SummonSpider[3].transform.position, gameObject.transform.rotation);
                    break;
                case 4:
                    Instantiate(BabySpider, SummonSpider[4].transform.position, gameObject.transform.rotation);
                    break;
            }
        }
    }
}




