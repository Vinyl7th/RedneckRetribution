using UnityEngine;
using System.Collections;

public class Player_Type_Resist : MonoBehaviour {

    // From Player
    float pDefense;
    int pRuneType;
    // 0 = No
    // 1 = Fire
    // 2 = Ice 
    // 3 = Poison
    // 4 = Dark

    // Data Members
    float incDamage;

    float runeResistFire = 0.8f;
    float runeResistIce = 0.8f;
    float runeResistPoison = 0.8f;
    float runeResistDark = 1.25f;

    float damageCooldown = 0.3f;
    float damageTimer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set player stats
        pDefense = gameObject.GetComponent<PlayerStats>().pDefense;
        pRuneType = gameObject.GetComponent<Player>().elementalType;

        // Set damage to 0
        incDamage = 0.0f;

        damageTimer += Time.deltaTime;
	}

    // If the player is hit by fire type damage
    public void TakeFireDamage(int _damage)
    {
        if (damageTimer >= damageCooldown)
        {
            incDamage = _damage;

            if (pRuneType == 1)
            {
                incDamage = incDamage * runeResistFire;
            }

            CalculateDamage(incDamage);
        }
    }

    // If the player is hit by ice type damage
    public void TakeIceDamage(int _damage)
    {
        if (damageTimer >= damageCooldown)
        {
            incDamage = _damage;

            if (pRuneType == 2)
            {
                incDamage = incDamage * runeResistIce;
            }

            CalculateDamage(incDamage);
        }
    }

    // If the player is hit by ice type damage
    public void TakePoisonDamage(int _damage)
    {
        if (damageTimer >= damageCooldown)
        {
            incDamage = _damage;

            if (pRuneType == 3)
            {
                incDamage = incDamage * runeResistPoison;
            }

            CalculateDamage(incDamage);
        }
    }

    // If the player is hit by ice type damage
    public void TakeDarkDamage(int _damage)
    {
        if (damageTimer >= damageCooldown)
        {
            incDamage = _damage;

            if (pRuneType == 3)
            {
                incDamage = incDamage * runeResistDark;
            }

            CalculateDamage(incDamage);
        }
    }

    // If the player is hit by ice type damage
    public void TakePhysicalDamage(int _damage)
    {
        if (damageTimer >= damageCooldown)
        {
            incDamage = _damage;

            CalculateDamage(incDamage);
        }
    }

    void CalculateDamage(float _damage)
    {
        damageTimer = 0.0f;
        incDamage = _damage;
        float def = 1.0f - pDefense;
        incDamage = incDamage * def;
    }
}
