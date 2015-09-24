using UnityEngine;
using System.Collections;

public class WastelandGun : MonoBehaviour {

   
    GameObject WastelandBoss;

    public GameObject Wastelandbullet;
    GameObject thePlayer;
    Vector3 player_pos;
    Vector3 pos;
    float angle;
    float fireRate = 0.0f;

    bool isRight;

    public int rariety;
    public int damage;
    public float ROF;
    public float accMin;
    public float accMax;




    // Use this for initialization
    void Start () {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        WastelandBoss = GameObject.FindGameObjectWithTag("Enemy");
    }
	
	// Update is called once per frame
	void Update () {

        fireRate += Time.deltaTime;
        player_pos = thePlayer.transform.position;
        pos = transform.position;
        player_pos.x = player_pos.x - pos.x;
        player_pos.y = player_pos.y - pos.y;
        player_pos.z = 2.0f;
        angle = Mathf.Atan2(-player_pos.y, -player_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Vector3 newPosition = WastelandBoss.transform.position;
        newPosition.z = -1.0f;
        transform.position = newPosition;

        if (thePlayer.transform.position.x > WastelandBoss.transform.position.x)
        {
            if (!isRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.y = -1;
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
                curScale.y = 1;
                transform.localScale = curScale;
                isRight = true;
            }
            else
                isRight = false;
        }


    }

    void ShootGun(int type)
    {
        
       
            Instantiate(Wastelandbullet, gameObject.transform.position, gameObject.transform.rotation);
            fireRate = 0;
    }
}
