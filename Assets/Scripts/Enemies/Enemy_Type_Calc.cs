using UnityEngine;
using System.Collections;

public class Enemy_Type_Calc : MonoBehaviour {

    public bool fireWeakness = false;
    public bool iceWeakness = false;
    public bool poisonWeakness = false;
    public bool darkWeakness = false;
    public bool physicalWeakness = false;

    float incPlayerDamage;
    int pRuneType;
 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            incPlayerDamage = coll.gameObject.GetComponent<AssaltBullet>().damage;
            incPlayerDamage = coll.gameObject.GetComponent<Pellet>().damage;
            incPlayerDamage = coll.gameObject.GetComponent<Bullet>().damage;
            incPlayerDamage = coll.gameObject.GetComponent<SniperShot>().damage;

            pRuneType = gameObject.GetComponent<Player>().elementalType;
        }
    }

    public void TakeFireDamage(int _damage)
    {
        incPlayerDamage = _damage;
        if (fireWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(_damage);
    }

    public void TakeIceDamage(int _damage)
    {
        incPlayerDamage = _damage;
        if (iceWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(_damage);
    }

    public void TakePoisonDamage(int _damage)
    {
        incPlayerDamage = _damage;
        if (poisonWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(_damage);
    }

    public void TakeDarkDamage(int _damage)
    {
        incPlayerDamage = _damage;
        if (darkWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(_damage);
    }

    public void TakePhysicalDamage(int _damage)
    {
        incPlayerDamage = _damage;
        if (physicalWeakness)
            incPlayerDamage = incPlayerDamage * 1.2f;

        CalculateDamage(_damage);
    }

    public void CalculateDamage(float _damage)
    {
        gameObject.SendMessage("RecieveDamage", _damage);
    }
}


