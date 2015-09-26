using UnityEngine;
using System.Collections;

public class RuneSpawner : MonoBehaviour
{
    public bool hardCode;
    public GameObject fireRune;
    public bool fire;
    public GameObject poisonRune;
    public bool poison;
    public GameObject iceRune;
    public bool ice;
    public GameObject darkRune;
    public bool dark;
    float percent;
    public int tier;
    // Use this for initialization
    void Start()
    {
        if(!hardCode)
        {
            switch(Random.Range(0,3))
            {
                case 0:
                    fire = true;
                    break;
                case 1:
                    ice = true;
                    break;
                case 2:
                    poison = true;
                    break;
                case 3:
                    dark = true;
                    break;
            }
            percent = Random.Range(0.0f, 1.0f);
            if(percent <= .65f)
            {
                tier = 1;
            }
            else if(percent <= .95)
            {
                tier = 2;
            }
            else if (percent <= 1)
            {
                tier = 3;
            }
           
        }
        if(fire)
        {
            fireRune.GetComponent<FireRune>().tier = tier;
            Instantiate(fireRune, transform.position, transform.rotation);
        }
        if(ice)
        {
            iceRune.GetComponent<IceRune>().tier = tier;
            Instantiate(iceRune, transform.position, transform.rotation);
        }
        if(poison)
        {
            poisonRune.GetComponent<PoisonRune>().tier = tier;
            Instantiate(poisonRune, transform.position, transform.rotation);
        }
        if (dark)
        {
            darkRune.GetComponent<DarkRune>().tier = tier;
            Instantiate(darkRune, transform.position, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
