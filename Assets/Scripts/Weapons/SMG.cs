using UnityEngine;
using System.Collections;

public class SMG : MonoBehaviour
{
    public GameObject bullet;
    Transform thePlayer;
    Transform Reticule;
    Vector3 Rec_pos;
    Vector3 pos;
    float angle;
    float fireRate = 0.0f;
    int element;
    bool isRight;
    public bool currWeapon = false;

    public int rariety;
    public int damage;
    public float ROF;
    public float accMin;
    public float accMax;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        Reticule = GameObject.FindGameObjectWithTag("Reticule").transform;
        RollStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (currWeapon)
            MoveGun();
        fireRate += Time.deltaTime;
        element = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().elementalType;

    }
    void MoveGun()
    {
        Rec_pos = Reticule.position;
        pos = transform.position;
        Rec_pos.x = Rec_pos.x - pos.x;
        Rec_pos.y = Rec_pos.y - pos.y;
        Rec_pos.z = 2.0f;
        angle = Mathf.Atan2(-Rec_pos.y, -Rec_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Set gun to layer above player
        Vector3 newPosition = thePlayer.transform.position;
        newPosition.z = -1.0f;
        transform.position = newPosition;

        if (Reticule.transform.position.x > thePlayer.transform.position.x)
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
        else
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
    }
    public void ChangeCurrent()
    {
        if (currWeapon)
            currWeapon = false;
        else
            currWeapon = true;
    }
    void ShootGun(int type)
    {

        if (fireRate >= ROF)
        {
            switch (element)
            {
                case 0:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(.90f, .90f, .90f);
                    break;
                case 1:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0, 0);
                    break;
                case 2:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f);
                    break;
                case 3:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
                    break;
            }
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bullet.GetComponent<Bullet>().accMin = accMin;
            bullet.GetComponent<Bullet>().accMax = accMax;
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            fireRate = 0;
        }

    }
    void RollStats()
    {
        if (rariety <= 64)
        {
            //common
            damage = Random.Range(15, 25);
            ROF = Random.Range(0.035f, 0.05f);
            accMin = -0.12f;
            accMax = 0.12f;
        }
        else if (rariety <= 94)
        {
            //unique
            damage = Random.Range(20, 30);
            ROF = Random.Range(0.03f, 0.04f);
            accMin = -0.1f;
            accMax = 0.11f;
        }
        else if (rariety <= 99)
        {
            //rare
            damage = Random.Range(30, 40);
            ROF = Random.Range(0.03f, 0.04f);
            accMin = -0.08f;
            accMax = 0.08f;
        }
        else if (rariety == 100)
        {
            //contraban
            damage = Random.Range(50, 75);
            ROF = Random.Range(0.01f, 0.0013f);
            accMin = -0.01f;
            accMax = 0.01f;
        }
    }

}

