﻿using UnityEngine;
using System.Collections;

public class IceRune : MonoBehaviour
{

    public bool current = false;
    bool active;
    bool spikeActive = false;
    public int charges;
    int element;
    Transform thePlayer;
    Vector3 offSet;
    public GameObject iceAura;
    public GameObject iceSpike;
    public GameObject snowBall;
    public int tier;
    float timer = 0.0f;


    float spikeSpawnCooldown;
    int spikeSpawned = 0;
    int spikeMax = 70;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        element = 2;
        if (tier == 1)
            charges = 5;
        if (tier == 2)
            charges = 5;
        if (tier == 3)
            charges = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            transform.position = GameObject.FindWithTag("HUDRune").transform.position;
        }
        timer += Time.deltaTime;
        if (charges == 0 && !active)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RuneDestroyed();
            Destroy(gameObject);
        }
        if (active)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(iceAura, thePlayer.position, thePlayer.rotation);
            }
            if (timer >= 10.0f)
            {
                active = false;
                timer = 0;
            }
        }
        if (spikeActive)
            IceSpike();
    }
    public void OnUse()
    {
        if (tier == 1)
            SnowBall();
        if (tier == 2)
            IceAura();
        if (tier == 3)
            IceSpike();
        charges--;
    }
    public void ChangeCurrent()
    {
        if (current)
        {

            current = false;
            transform.position = GameObject.FindWithTag("Player").transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetElement(element);
            current = true;
        }

    }
    void IceAura()
    {
        active = true;
        timer = 0;
    }
    void IceSpike()
    {
        spikeSpawnCooldown += Time.deltaTime;
        spikeActive = true;
        if (spikeSpawned == spikeMax)
        {
            spikeActive = false;
            spikeSpawned = 0;
            //charges--;
        }
        if (spikeSpawnCooldown >= 0.1f)
        {
            Instantiate(iceSpike, GameObject.FindGameObjectWithTag("Reticule").transform.position, thePlayer.transform.rotation);
            spikeSpawned++;
            spikeSpawnCooldown = 0.0f;
        }
    }
    void SnowBall()
    {
        Instantiate(snowBall, thePlayer.position, thePlayer.rotation);
    }
}
