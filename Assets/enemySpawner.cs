﻿using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] enemies;
    

    int numEnemies = 0;
    int enemyChoice = 0;

	// Use this for initialization
	void Start ()
    {

        numEnemies = enemies.Length;
        enemyChoice = Random.Range(0, numEnemies);
        Instantiate(enemies[enemyChoice], gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
