using UnityEngine;
using System.Collections;

public class GunSpawner : MonoBehaviour
{
    public bool hardCode;
    public GameObject theSMG;
    public bool SMG;
    public GameObject theShotGun;
    public bool ShotGun;
    public GameObject theSniper;
    public bool Sniper;
    public GameObject theAssaltRifle;
    public bool AssaltRifle;

    public bool common;
    public bool unique;
    public bool rare;
    public bool contraband;
    int rariety = -1;

    // Use this for initialization
    void Start()
    {
        if (!hardCode)
        {

            switch (Random.Range(0, 4))
            {
                case 0:
                    SMG = true;
                    break;
                case 1:
                    ShotGun = true;
                    break;
                case 2:
                    Sniper = true;
                    break;
                case 3:
                    AssaltRifle = true;
                    break;

            }
        }
        if (common)
        {
            rariety = 1;
        }
        if (unique)
        {
            rariety = 93;
        }
        if (rare)
        {
            rariety = 99;
        }
        if (contraband)
        {
            rariety = 100;
        }
        if (SMG)
            CreateSMG();
        if (ShotGun)
            CreateShotGun();
        if (Sniper)
            CreateSniper();
        if (AssaltRifle)
            CreateAssalt();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateSMG()
    {
        if (rariety == -1)
            rariety = Random.Range(0, 100);
        theSMG.GetComponent<SMG>().rariety = rariety;
        Instantiate(theSMG, transform.position, transform.rotation);
    }
    void CreateShotGun()
    {
        if (rariety == -1)
            rariety = Random.Range(0, 100);
        theShotGun.GetComponent<ShotGun>().rariety = rariety;
        Instantiate(theShotGun, transform.position, transform.rotation);
    }
    void CreateSniper()
    {
        if (rariety == -1)
            rariety = Random.Range(0, 100);
        theSniper.GetComponent<Sniper>().rariety = rariety;
        Instantiate(theSniper, transform.position, transform.rotation);
    }
    void CreateAssalt()
    {
        if (rariety == -1)
            rariety = Random.Range(0, 100);
        theAssaltRifle.GetComponent<AssaltRifle>().rariety = rariety;
        Instantiate(theAssaltRifle, transform.position, transform.rotation);
    }
}
