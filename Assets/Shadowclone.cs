using UnityEngine;
using System.Collections;

public class Shadowclone : MonoBehaviour {

    GameObject thePlayer;
    public GameObject HisGun;
    public GameObject HisGun2;
    public GameObject HisGun3;
    GameObject currGun;
    bool isRight;

    Animator theAnimator;

    GameObject[] Waypoint;
    GameObject _waypoint;
    [SerializeField]
    AudioSource bulletShootNoise;
    [SerializeField]
    AudioSource shellFallNoise;
    [SerializeField]
    AudioSource hurtSound;
    [SerializeField]
    GameObject thePortal;


    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;

    bool _Find;
    bool _Fire;
    int count = 0;
    float fireDelay;
    bool check1, check2, check3, switch1, switch2;

    public float moveSpeed,
          maxHealth,
          hitPoints;
    int waypathing;
    float distance;

    // Use this for initialization
    void Start()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().SetMusic(8);

        check1 = true;
        check2 = false;
        check3 = false;
        theAnimator = gameObject.GetComponent<Animator>();
        bulletShootNoise.volume = shellFallNoise.volume = hurtSound.volume = soundController.sfxValue;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        currGun = (GameObject)Instantiate(HisGun, gameObject.transform.position, gameObject.transform.rotation);
        //HisGun = GameObject.FindWithTag("Boss_Gun");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
        _Fire = false;
        fireDelay = 0;
        moveSpeed = 5f;
        hitPoints = 30000.0f;
        maxHealth = hitPoints;
        Waypoint = GameObject.FindGameObjectsWithTag("Boss_Waypoint");
        _waypoint = GameObject.FindGameObjectWithTag("shadowwaypoint");


    }

    // Update is called once per frame
    void Update()
    {

        fireDelay += Time.deltaTime;
        if (gameObject.transform.position.x > thePlayer.transform.position.x)
        {
            if (!isRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.x = -1;
                transform.localScale = curScale;
                isRight = true;
            }
            else
            {
                isRight = false;

            }
        }
        else
        {
            if (!isRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.x = 1;
                transform.localScale = curScale;
                isRight = true;
            }
            else
            {
                isRight = false;

            }

        }


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

        if (_Fire == true)
        {
            theAnimator.SetBool("walkRight", false);
            if (check1 == true)
            {
                if (fireDelay >= 0.09f)
                {
                    //calling the function to fire the fireball
                   bulletShootNoise.Play();
                   shellFallNoise.Play();
                   currGun.SendMessage("ShootGun");

                    count++;
                    if (count == 15)
                    {
                        _Fire = false;
                        _Find = true;
                    }

                    fireDelay = 0;
                }
            }
           else if (check2 == true)
            {

                //calling the function to fire the fireball

               currGun.SendMessage("ShootGun");

                count++;
                if (count == 20)
                {
                    bulletShootNoise.Play();
                    shellFallNoise.Play();
                    _Fire = false;
                    _Find = true;
                }

                fireDelay = 0;
            }

          else if (check3 == true)
            {
                if (fireDelay >= 0.09f)
                {
                    //calling the function to fire the fireball
                    bulletShootNoise.Play();
                    shellFallNoise.Play();
                    currGun.SendMessage("ShootGun");

                    count++;
                    if (count == 15)
                    {
                        _Fire = false;
                        _Find = true;
                    }

                    fireDelay = 0;
                }
            }
        }
        else
        {
            count = 0;
            Move();
        }

        if (hitPoints / maxHealth <= 0.66f && hitPoints / maxHealth >= 0.1f)
        {
            check1 = false;
            check2 = true;

            if (switch1 == false)
            {
                waypathing = 4;
                Destroy(currGun);
                currGun = (GameObject)Instantiate(HisGun2, gameObject.transform.position, gameObject.transform.rotation);
                //HisGun2 = GameObject.FindWithTag("Boss_Gun");
                switch1 = true;
            }
        }
       else if (hitPoints / maxHealth <= 0.1f && hitPoints / maxHealth > 0f)
        {
            check2 = false;
            check3 = true;
            
            if (switch2 == false)
            {
                waypathing = 4;
                Destroy(HisGun2);
                currGun = (GameObject)Instantiate(HisGun3, gameObject.transform.position, gameObject.transform.rotation);
               // HisGun3 = GameObject.FindWithTag("Boss_Gun");
                switch2 = true;
            }
        }

        //if the healthpoints are 0 destroy the enemy on screen
       else if (hitPoints < 0.0f)
        {
            Destroy(currGun);
            GameObject.FindGameObjectWithTag("LevelManager").SendMessage("LoadLevel");
            Instantiate(thePortal, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }

    public void RecieveDamage(float _dmg)
    {
        hurtSound.Play();
        hitPoints -= _dmg;
        changeColor = true;

    }


    void Move()
    {
        if (_Find == true)
        {
            waypathing = Random.Range(0, 4);
            _Find = false;
        }
        float movetoWaypoint;

        switch (waypathing)
        {
            case 0:
                theAnimator.SetBool("walkRight", true);
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[0].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[0].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 1:
                theAnimator.SetBool("walkRight", true);
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[1].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[1].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 2:
                theAnimator.SetBool("walkRight", true);
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[2].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[2].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 3:
                theAnimator.SetBool("walkRight", true);
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[3].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[3].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 4:
                theAnimator.SetBool("walkRight", true);
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, _waypoint.transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _waypoint.transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;

        }
    }


}
