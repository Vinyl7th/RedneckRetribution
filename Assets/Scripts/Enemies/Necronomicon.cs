using UnityEngine;
using System.Collections;

public class Necronomicon : MonoBehaviour {

    public int bossState = 0;              // Phase 1 - 100% health, follow player
    bool isRight = false;

    public bool bossFight;
    public bool shootBalls = false;
    public float bHP_Max;
    public float bHP_Curr;
    public float moveSpeed = 4.0f;

    public float attackCooldown = 0.0f;
    public float attackThreshold = 10.0f;
    public float ballCooldown = 0.0f;
    float shootAngle;

    public Sprite sprite_Idle;
    public Sprite sprite_Attack;
    public Sprite sprite_Follow;

    public GameObject thePlayer;

    public Transform theFireball;
    public Transform spawnPos;
    public Transform healthBar;

    Vector3 playerWaypoint;

    // Shit I dont want to deal with
    [SerializeField]
    AudioSource damageNoise;

    [SerializeField]
    AudioSource attackNoise;

    float delayColorChanger;
    bool changeColor = false;

    // Fireball stuff
    public Sprite sprite_fireball;
    public Sprite sprite_iceball;
    public Sprite sprite_poisonball;
    public Sprite sprite_darkball;

    bool dashAttack = true;
    public Vector2 moveToThis;
    public Vector2 tempPlayer;


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
            ballCooldown += Time.deltaTime;

            if (bossState == 1)
            {
                ChasePlayer();
            }
            else if(bossState >= 2 && bossState < 5)
            {
                if(attackCooldown >= attackThreshold)
                {
                    FireballAttack();
                    attackCooldown = 0.0f;
                    dashAttack = true;
                }
                if(attackCooldown >= 2.9f && attackCooldown < 3.0f)
                    SetDash();

                if (attackCooldown >= 3.0f)
                {
                    if (dashAttack)
                    {
                        Dash();
                        // dashAttack = false;
                    }
                    shootBalls = false;
                }

                if (attackCooldown >= 4.5f)
                {
                    ChasePlayer();
                    dashAttack = false;
                }
            }
            else if(bossState == 3)
            {

            }
            else if (bossState == 4)
            {

            }
            else if (bossState == 5)
            {
                ChasePlayer();
                LaunchFireballs();
                shootBalls = true;
            }

            if (shootBalls)
            {
                if (ballCooldown >= 0.03f)
                {
                    shootAngle += Time.deltaTime * 2080.0f;
                    Vector3 axis = new Vector3(0, 0, shootAngle);
                    gameObject.transform.rotation = Quaternion.Euler(axis);
                    ShootFireball();
                    ballCooldown = 0.0f;
                }
            }
            else
            {
                Vector3 axis = new Vector3(0, 0, 0);
                gameObject.transform.rotation = Quaternion.Euler(axis);
            }


            // Damage color
            if (changeColor == true)
            {
                //start the delaytimer and change the enemy's color to red
                delayColorChanger += Time.deltaTime;
                Color newColor = new Color(1.0f, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().color = newColor;

                Color baseColor;
                baseColor = new Color(1.0f, 1.0f, 1.0f);

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

        if (gameObject.transform.position.x > thePlayer.transform.position.x)
        {
            if (!isRight)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                isRight = true;
            }
            else
                isRight = false;
        }
        else
        {
            if (!isRight)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                isRight = true;
            }
            else
                isRight = false;
        }

        
    }

    void FindState()
    {
        if (bHP_Curr == bHP_Max)
            bossState = 1;
        else if (bHP_Curr / bHP_Max >= 0.75f)
        {
            bossState = 2;
        }
        else if (bHP_Curr / bHP_Max >= 0.5f)
        {
            bossState = 3;
        }
        else if (bHP_Curr / bHP_Max >= 0.25f)
        {
            bossState = 4;
        }
        else if(bHP_Curr / bHP_Max >= 0.00f)
            bossState = 5;

        if (bHP_Curr <= 0.0f)
        {
            Cursor.visible = true;
            Application.LoadLevel("Menu_Credits");
        }

    }

    void LaunchFireballs()
    {
        shootBalls = true;
    }

    public void ActivateIt()
    {
        bossFight = true;
        gameObject.tag = "Enemy";
        gameObject.transform.position = spawnPos.transform.position;
    }

    public void ChasePlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite_Follow;
        //Set the player movement every frame to 0x 0y
        Vector2 moveEnemy = new Vector2(0, 0);

        // tracks the distance to the player's position from the skeleton's position

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
        Vector2 newVel = new Vector2(0, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite_Attack;
        gameObject.GetComponent<Rigidbody2D>().velocity = newVel;
        shootBalls = true;
    }

    public void RecieveDamage(float _dmg)
    {
        damageNoise.Play();
        bHP_Curr -= _dmg;
        changeColor = true;

    }

    void ShootFireball()
    {
        Transform temp = Instantiate(theFireball, gameObject.transform.position, gameObject.transform.rotation) as Transform;

        temp.GetComponent<Fireball>().damage = 100.0f;
        int randomColor = Random.Range(0, 4);
        Color newColor;
        newColor.a = 1.0f;
        newColor.r = Random.Range(0.8f, 1.0f);
        newColor.g = Random.Range(0.8f, 1.0f);
        newColor.b = Random.Range(0.8f, 1.0f);

        if (randomColor == 0)
        {
            temp.GetComponent<SpriteRenderer>().sprite = sprite_fireball;
            newColor.r = Random.Range(0.99f, 1.0f);
            newColor.g = Random.Range(0.7f, 1.0f);
            newColor.b = Random.Range(0.7f, 1.0f);
        }

        if (randomColor == 1)
        {
            temp.GetComponent<SpriteRenderer>().sprite = sprite_iceball;
            newColor.r = Random.Range(0.7f, 1.0f);
            newColor.g = Random.Range(0.7f, 1.0f);
            newColor.b = Random.Range(0.99f, 1.0f);
        }

        if (randomColor == 2)
        {
            temp.GetComponent<SpriteRenderer>().sprite = sprite_poisonball;
            newColor.r = Random.Range(0.7f, 1.0f);
            newColor.g = Random.Range(0.99f, 1.0f);
            newColor.b = Random.Range(0.7f, 1.0f);
        }

        if(randomColor == 3)
        {
            temp.GetComponent<SpriteRenderer>().sprite = sprite_darkball;
        }

       // temp.GetComponent<SpriteRenderer>().color = newColor;

    }

    void SetDash()
    {
        moveToThis = thePlayer.transform.position;

        moveToThis.x -= (gameObject.transform.position.x - thePlayer.transform.position.x) * 0.5f;
        moveToThis.y -= (gameObject.transform.position.y - thePlayer.transform.position.y) * 0.5f;
    }

    void Dash()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToThis, (moveSpeed * 3.0f) * Time.deltaTime);
    }
}
