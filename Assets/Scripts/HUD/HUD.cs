﻿using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    GameObject thePlayer;
    public GameObject healthBar;
    public Transform healthBarAnchor;
    Vector3 healthBarInit;
    Vector3 healthBarPos;

    float MaxHP;
    float CurrHP;

	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.FindWithTag("Player");
        healthBarPos = healthBar.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBarInit = healthBarAnchor.transform.position;

        MaxHP = thePlayer.GetComponentInParent<PlayerStats>().pHealthMax;
        CurrHP = thePlayer.GetComponentInParent<PlayerStats>().pHealthCurr;

        float ratio = CurrHP / MaxHP;

        healthBarInit.x -= (4f * (1.0f - ratio));
        healthBar.transform.position = healthBarInit;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = ratio;
        healthBar.transform.localScale = scale;
    }
}
