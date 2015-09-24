using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    GameObject thePlayer;
    public GameObject healthBar;
    Vector3 healthBarInit;
    Vector3 healthBarPos;

    float MaxHP;
    float CurrHP;

	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.FindWithTag("Player");
        healthBarInit = healthBar.transform.position;
        healthBarPos = healthBar.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MaxHP = gameObject.GetComponentInParent<PlayerStats>().pHealthMax;
        CurrHP = gameObject.GetComponentInParent<PlayerStats>().pHealthCurr;

        float ratio = CurrHP / MaxHP;

        healthBarPos.z = -9.5f;
        healthBarPos.x -= (0.5f * (1.0f - ratio));
        healthBar.transform.position = healthBarPos;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = ratio;
        healthBar.transform.localScale = scale;
    }
}
