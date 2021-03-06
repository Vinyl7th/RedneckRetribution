﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    float bulletSpeed;
    float accuracy;
    public float accMin;
    public float accMax;
    float displayDelay = 0.0f;
    public float damage;
    GameObject thePlayer;
    Vector3 playerPos;
    Transform reticule;

    void Start()
    {
        bulletSpeed = 16.0f;
        accuracy = Random.Range(-0.08f, 0.08f);
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerPos = thePlayer.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        reticule = GameObject.FindGameObjectWithTag("Reticule").transform;
        Vector3 direction = reticule.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    void Update()
    {
        displayDelay += Time.deltaTime;
        transform.Translate(new Vector3(bulletSpeed * Time.deltaTime, accuracy , 0));
        if (displayDelay >= 0.02f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Vector3.Distance(transform.position, playerPos) >= 15.0f)
            Destroy(gameObject);


    }

    public void SetDamage(int dam)
    {
        damage = dam;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           // other.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }


        if (other.gameObject.tag == "Default")
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
