using UnityEngine;
using System.Collections;

public class Necronomicon : MonoBehaviour {

    public int bossState = 0;              // Phase 1 - 100% health, follow player

    public bool bossFight;
    public float bHP_Max;
    public float bHP_Curr;
    public float moveSpeed = 4.0f;

    public float attackCooldown = 0.0f;
    public float attackThreshold = 10.0f;

    public Sprite sprite_Idle;
    public Sprite sprite_Attack;
    public Sprite sprite_Follow;

    public GameObject thePlayer;

    Vector3 playerWaypoint;

    // Shit I dont want to deal with
    [SerializeField]
    AudioSource damageNoise;

    [SerializeField]
    AudioSource attackNoise;

    Color baseColor;
    float delayColorChanger;
    float healthRegenTimer = 0.0f;
    bool changeColor = false;


    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite_Idle;
        thePlayer = GameObject.FindWithTag("Player");

        bHP_Max = 50000;
        bHP_Curr = bHP_Max;

        bossFight = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (bossFight)
        {
            FindState();
            attackCooldown += Time.deltaTime;

            if (bossState == 1)
            {
                ChasePlayer();
            }
            else if(bossState == 2)
            {
                if(attackCooldown >= attackThreshold)
                {
                    FireballAttack();
                }

                if (attackCooldown >= 3.0f)
                    ChasePlayer();
            }




            // Damage color
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

        }
	}

    void FindState()
    {
        if (bHP_Curr == bHP_Max)
            bossState = 1;
        else if(bHP_Curr / bHP_Max >= 75.0f)
        {
            bossState = 2;
        }


    }

    void LaunchFireballs(int _numFireballs)
    {

    }

    public void ActivateIt()
    {
        bossFight = true;
        gameObject.tag = "Enemy";
    }

    public void ChasePlayer()
    {
        //Set the player movement every frame to 0x 0y
        Vector2 moveEnemy = new Vector2(0, 0);

        // tracks the distance to the player's position from the skeleton's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position,
            gameObject.transform.position);

            //temp varibles for the player's and enemies's position
            float playerX = thePlayer.transform.position.x;
            float playerY = thePlayer.transform.position.y;
            float enemyX = gameObject.transform.position.x;
            float enemyY = gameObject.transform.position.y;

            //chase player
            if (playerX > enemyX)        // enemy move right
                moveEnemy.x = moveSpeed;
            if (playerX < enemyX)        // enemy move left
                moveEnemy.x = -moveSpeed;
            if (playerY > enemyY)        // enemy move up
                moveEnemy.y = moveSpeed;
            if (playerY < enemyY)        // enemy move down
                moveEnemy.y = -moveSpeed;

        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
    }

    void FireballAttack()
    {

    }

    public void RecieveDamage(float _dmg)
    {
        damageNoise.Play();
        bHP_Curr -= _dmg;
        changeColor = true;

    }
}
