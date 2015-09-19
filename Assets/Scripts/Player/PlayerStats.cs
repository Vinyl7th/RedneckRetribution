using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    // Player Stats
    
    public float pHealthMax = 0.0f;
    public float pHealthCurr = 0.0f;
    public float pAttack = 0.0f;
    public float pDefense = 0.0f;
    public float pAttackSpeed = 0.0f;
    public float pMoveSpeed = 0.0f;
    public float pLifeSteal = 0.0f;

    public bool pIsAlive = true;



	// Use this for initialization
	void Start ()
    {
        pDefense = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(float _damage)
    {
        pHealthCurr -= _damage;
        if (pHealthCurr <= 0.0f)
        {
            pHealthCurr = 0.0f;
            pIsAlive = false;
        }
    }
}
