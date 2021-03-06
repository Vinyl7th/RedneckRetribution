﻿using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{

    [SerializeField]
    GameObject rain;
    [SerializeField]
    GameObject snow;
    [SerializeField]
    GameObject lightning;
    [SerializeField]
    AudioSource rainSFX;
    [SerializeField]
    AudioSource lightningSFX;
    int effect;
    float offsetX;
    float offsetY;
    Vector3 position;
    float timer = 0.0f;
    float idk;
    // Use this for initialization
    void Start()
    {
        idk = Random.Range(4.0f, 10.0f);
        rainSFX.volume = lightningSFX.volume = soundController.sfxValue;
    }

    // Update is called once per frame
    void Update()
    {
        effect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().weatherType;
        if (effect == 0)
        {
            rainSFX.Stop();
        }
        else if (effect == 1)
        {
            timer += Time.deltaTime;
            for (int i = 0; i < 3; i++)
            {
                if (!rainSFX.isPlaying)
                    rainSFX.Play();
                position = Camera.main.transform.position;
                position.z = 1;
                offsetX = Random.Range(-16.0f, 16.0f);
                offsetY = Random.Range(-10.0f, 10.0f);
                position.x += offsetX;
                position.y += offsetY;
                Instantiate(rain, position, rain.transform.rotation);
                if(timer >= idk)
                {
                    idk = Random.Range(4.0f, 10.0f);
                    position = Camera.main.transform.position;
                    position.z = -8;
                    if (!lightningSFX.isPlaying)
                        lightningSFX.Play();
                    Instantiate(lightning, position, lightning.transform.rotation);
                    timer = 0.0f;
                }
            }
        }
        else if (effect == 2)
        {
                rainSFX.Stop();
            for (int i = 0; i < 3; i++)
            {

                position = Camera.main.transform.position;
                position.z = 1;
                offsetX = Random.Range(-16.0f, 16.0f);
                offsetY = Random.Range(-10.0f, 10.0f);
                position.x += offsetX;
                position.y += offsetY;
                Instantiate(snow, position, rain.transform.rotation);
            }
        }
    }
}

