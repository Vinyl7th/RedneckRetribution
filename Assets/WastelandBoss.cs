using UnityEngine;
using System.Collections;

public class WastelandBoss : MonoBehaviour {

    GameObject thePlayer;
    public GameObject HisGun;
    bool isRight;

    GameObject[] Waypoint;

    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;

    bool _Fire;
    int count = 0;
    float fireDelay;

    public float moveSpeed,
          maxHealth,
          hitPoints;


    // Use this for initialization
    void Start () {
        
        Instantiate(HisGun, transform.position, transform.rotation);
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
        _Fire = false;
        fireDelay = 0;
        moveSpeed = 5f;
        hitPoints = 15000.0f;
        maxHealth = hitPoints;
        Waypoint = GameObject.FindGameObjectsWithTag("Boss_Waypoint");

    }
	
	// Update is called once per frame
	void Update () {

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
                isRight = false;
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
                isRight = false;
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

            if (fireDelay >= 0.09f)
            {
                //calling the function to fire the fireball
                HisGun.SendMessage("ShootGun");
                count++;
                if (count == 15)
                    _Fire = false;
                fireDelay = 0;
            }

        }
        else
        {
            count = 0;
            Move();
        }

    }

    public void RecieveDamage(float _dmg)
    {
        hitPoints -= _dmg;
        changeColor = true;

    }


    void Move()
    {
       int waypathing = Random.Range(0, 4);
        float distance;
        float movetoWaypoint;

        switch (waypathing)
        {
            case 0:
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[0].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[0].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 1:
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[1].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[1].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 2:
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[2].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[2].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 3:
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[3].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[3].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;
            case 4:
                movetoWaypoint = moveSpeed * Time.deltaTime;
                distance = Vector2.Distance(gameObject.transform.position, Waypoint[4].transform.position);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Waypoint[4].transform.position, movetoWaypoint);
                _Fire = false;
                if (distance <= 2)
                    _Fire = true;
                break;

        }
    }


}
