using UnityEngine;
using System.Collections;

public class ShotGun : MonoBehaviour
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
        {
            MoveGun();
            SendStats();
        }
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
            for (int i = 0; i < 15; i++)
            {
                bullet.GetComponent<Pellet>().SetDamage(damage);
                bullet.GetComponent<Pellet>().accMin = accMin;
                bullet.GetComponent<Pellet>().accMax = accMax;
                Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);

            }
            fireRate = 0;
        }

    }
    void RollStats()
    {
        if (rariety <= 64)
        {
            //common
            damage = Random.Range(110, 140);
            ROF = Random.Range(0.75f, 1);
            accMin = -0.2f;
            accMax = 0.2f;

        }
        else if (rariety <= 94)
        {
            //unique
            damage = Random.Range(170, 230);
            ROF = Random.Range(0.45f, 0.65f);
            accMin = -0.1f;
            accMax = 0.1f;
        }
        else if (rariety <= 99)
        {
            //rare
            damage = Random.Range(250, 325);
            ROF = Random.Range(0.3f, 0.4f);
            accMin = -0.05f;
            accMax = 0.05f;
        }
        else if (rariety == 100)
        {
            //contraban
            damage = Random.Range(420, 640);
            ROF = Random.Range(0.2f, 0.1f);
            accMin = -0.02f;
            accMax = 0.02f;
        }
    }

    void SendStats()
    {
        GameObject theCamera = GameObject.FindWithTag("Flavor");

        theCamera.GetComponent<FlavorText>().hWeaponStyle.text = "Shotgun";
        theCamera.GetComponent<FlavorText>().hAttack.text = damage.ToString();
        string rate = string.Format("{0:0.00}", ROF);
        theCamera.GetComponent<FlavorText>().hFireRate.text = rate;
        theCamera.GetComponent<FlavorText>().hAccuracy.text = (accMax - accMin).ToString();

        if (rariety < 64)
        {
            theCamera.GetComponent<FlavorText>().hRarity.text = "Common";
            Color newColor = new Color(0.9f, 0.9f, 0.9f);
            theCamera.GetComponent<FlavorText>().hRarity.color = newColor;
        }
        else if (rariety < 94)
        {
            theCamera.GetComponent<FlavorText>().hRarity.text = "Uncommon";
            Color newColor = new Color(0.1f, 0.9f, 0.1f);
            theCamera.GetComponent<FlavorText>().hRarity.color = newColor;
        }
        else if (rariety <= 99)
        {
            theCamera.GetComponent<FlavorText>().hRarity.text = "Rare";
            Color newColor = new Color(0.9f, 0.1f, 0.9f);
            theCamera.GetComponent<FlavorText>().hRarity.color = newColor;
        }
        else
        {
            theCamera.GetComponent<FlavorText>().hRarity.text = "Contraband";
            Color newColor = new Color(0.9f, 0.5f, 0.1f);
            theCamera.GetComponent<FlavorText>().hRarity.color = newColor;
        }
    }

}