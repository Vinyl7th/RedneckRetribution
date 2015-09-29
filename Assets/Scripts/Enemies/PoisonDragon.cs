using UnityEngine;
using System.Collections;

public class PoisonDragon : MonoBehaviour
{

    GameObject thePlayer;
    GameObject[] Waypoint;
    GameObject DragonControl;
    public GameObject fireball;

    //varibles for the visual feedback when the skeleton takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;

   public  bool active = false;
    bool _Find;
    bool _Fire;
    int count = 0;
    float fireDelay;

    public float moveSpeed,
          maxHealth,
          hitPoints;
    int waypathing;
    float distance;

    // Use this for initialization
    void Start()
    {
        //save the color of the enemy at start and have a bool set to false
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
        moveSpeed = 5f;
        hitPoints = 10000.0f;
        maxHealth = hitPoints;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        Waypoint = GameObject.FindGameObjectsWithTag("Boss_Waypoint");
        DragonControl = GameObject.FindGameObjectWithTag("DragonControl");
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (hitPoints > maxHealth)
                hitPoints = maxHealth;
           
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
            if (hitPoints < 0.0f)
            {
                DragonControl.SendMessage("SwitchDragon");
                Destroy(gameObject);
            }
            fireDelay += Time.deltaTime;
            if (_Fire == true)
            {

                if (fireDelay >= 0.10f)
                {
                    //calling the function to fire the fireball
                    //HisGun.SendMessage("ShootGun");
                    ShootFireBall();
                    count++;
                    if (count == 15)
                    {
                        _Fire = false;
                        _Find = true;
                    }

                    fireDelay = 0;
                }

            }
            else
            {

                count = 0;
                Move();
            }

        }
    }

    public void RecieveDamage(float _dmg)
    {
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
    void ShootFireBall()
    {
        for (int i = 0; i < 4; i++)
        {

            Instantiate(fireball, transform.position, transform.rotation);
        }
    }
}
