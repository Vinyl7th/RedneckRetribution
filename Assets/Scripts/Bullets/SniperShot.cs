﻿using UnityEngine;
using System.Collections;

public class SniperShot : MonoBehaviour
{

    float bulletSpeed;
    float accuracy;
    float displayDelay = 0.0f;
    public int damage;
    GameObject thePlayer;
    Vector3 playerPos;
    Transform reticule;

    void Start()
    {
        bulletSpeed = 25.0f;
        accuracy = 0;
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
        transform.Translate(new Vector3(bulletSpeed * Time.deltaTime, accuracy, 0));
        if (displayDelay >= 0.07f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Vector3.Distance(transform.position, playerPos) >= 30.0f)
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
            //other.gameObject.SendMessage("TakeDamage", damage);

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Default")
        {
            Destroy(gameObject);
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Enemy")
            Destroy(gameObject);
    }

}
