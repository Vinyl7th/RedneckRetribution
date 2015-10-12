using UnityEngine;
using System.Collections;

public class Enemy_Type_Calc : MonoBehaviour
{

    GameObject thePlayer;

    public bool fireWeakness = false;
    public bool iceWeakness = false;
    public bool poisonWeakness = false;
    public bool darkWeakness = false;
    public bool physicalWeakness = false;

    float incPlayerDamage;
    int pRuneType;


    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            int type = coll.gameObject.GetComponent<BulletID>().bulletType;

            if (type == 1)
                incPlayerDamage = coll.gameObject.GetComponent<AssaltBullet>().damage;
            if (type == 2)
                incPlayerDamage = coll.gameObject.GetComponent<Pellet>().damage;

            if (type == 3)
                incPlayerDamage = coll.gameObject.GetComponent<Bullet>().damage;

            if (type == 4)
                incPlayerDamage = coll.gameObject.GetComponent<SniperShot>().damage;
            if (type == 5)
                incPlayerDamage = coll.gameObject.GetComponent<SnowBall>().damage;
            if (type == 6)
                incPlayerDamage = coll.gameObject.GetComponent<SiphonShot>().damage;
            if (type == 7)
                incPlayerDamage = coll.gameObject.GetComponent<DemonShot>().damage;
           


            pRuneType = thePlayer.GetComponent<Player>().elementalType;

            if (pRuneType == 1)
                TakeFireDamage(incPlayerDamage);

            if (pRuneType == 2)
                TakeIceDamage(incPlayerDamage);

            if (pRuneType == 3)
                TakePoisonDamage(incPlayerDamage);

            if (pRuneType == 4)
                TakeDarkDamage(incPlayerDamage);

            if (pRuneType == 0)
                TakePhysicalDamage(incPlayerDamage);

            //coll.SendMessage("DestroySelf");
        }
    }

    public void TakeFireDamage(float _damage)
    {
        incPlayerDamage = _damage;
        if (fireWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;
       
        CalculateDamage(incPlayerDamage);
    }

    public void TakeIceDamage(float _damage)
    {
        incPlayerDamage = _damage;
        if (iceWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(incPlayerDamage);
    }

    public void TakePoisonDamage(float _damage)
    {
        incPlayerDamage = _damage;
        if (poisonWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(incPlayerDamage);
    }

    public void TakeDarkDamage(float _damage)
    {
        incPlayerDamage = _damage;
        if (darkWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(incPlayerDamage);
    }

    public void TakePhysicalDamage(float _damage)
    {
        incPlayerDamage = _damage;

        CalculateDamage(incPlayerDamage);
    }

    public void CalculateDamage(float _damage)
    {
        _damage = _damage + (_damage * thePlayer.GetComponent<PlayerStats>().pAttack);
        gameObject.SendMessage("RecieveDamage", _damage);

        // UI 
        Vector3 _pos = gameObject.transform.position;
        _pos.y += 3.0f;

        int theDamage = (int)_damage;

        GameObject theCanvas = GameObject.FindWithTag("TextSpawner");
        theCanvas.GetComponent<TextSpawner>().SpawnTheText(theDamage, _pos);
    }
}


