﻿using UnityEngine;
using System.Collections;

public class audioSourceMusic : MonoBehaviour {
    

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
       

        gameObject.GetComponent<AudioSource>().volume = soundController.musicValue;
    }
}
