using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    // Player Stats
    
    public float pHealthMax = 1000.0f;
    public float pHealthCurr = 1000.0f;
    public float pAttack = 0.0f;
    public float pDefense = 0.0f;
    public float pAttackSpeed = 0.0f;
    public float pMoveSpeed = 0.0f;
    public float pLifeSteal = 0.0f;

    public bool pIsAlive = true;
    AudioSource src;


	// Use this for initialization
	void Start ()
    {
        pDefense = 0;
        src = gameObject.GetComponent<AudioSource>();
        src.volume = soundController.sfxValue;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       // pHealthCurr += 0.1f;

        if(pHealthCurr > pHealthMax)
        {
            pHealthCurr = pHealthMax;
        }
	}

    public void TakeDamage(float _damage)
    {
        src.Play();
        pHealthCurr -= _damage;
       // if (pHealthCurr <= 0.0f)
       // {
            
           // pHealthCurr = 0.0f;
            //pIsAlive = false;
            //Application.LoadLevel("Menu_Main");
       // }
    }
}
