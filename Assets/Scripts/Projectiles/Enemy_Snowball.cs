﻿using UnityEngine;
using System.Collections;

public class Enemy_Snowball : MonoBehaviour
{

    GameObject thePlayer;


    Vector3 playerPos;

    public float damage;
    float fireballSpeed,
           accuracy,
           displayDelay;
    Vector3 direction;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {

        fireballSpeed = 15;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        accuracy = Random.Range(-0.05f, 0.05f);
        direction = thePlayer.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 8.0f)
            Destroy(gameObject);

        transform.Translate(new Vector3(fireballSpeed * Time.deltaTime, accuracy, 0));

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("TakeIceDamage", 75);
            Destroy(gameObject);
        }

        // if (other.gameObject.tag != "Enemy")
        Destroy(gameObject);

    }
}
