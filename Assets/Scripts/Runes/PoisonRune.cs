using UnityEngine;
using System.Collections;

public class PoisonRune : MonoBehaviour
{

    public bool current = false;

    public int charges;
    int element;
    Transform thePlayer;
    public GameObject swordsDance;
    public GameObject toxicEmmiter;
    public GameObject siphonShot;
    public int tier;
    bool active;
    float angle = 0.0f;



    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        element = 3;
        charges = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            transform.position = GameObject.FindWithTag("HUDRune").transform.position;
        }
        if (charges == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RuneDestroyed();
            Destroy(gameObject);
        }

    }
    public void OnUse()
    {
        if (tier == 1)
            SwordsDance();
        if (tier == 2)
            ToxicCloud();
        if (tier == 3)
            SiphonShot();
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
            transform.position = GameObject.FindWithTag("HUDRune").transform.position;
        }

    }
    void SwordsDance()
    {
        for (int i = 0; i < 30; i++)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Instantiate(swordsDance, thePlayer.position, gameObject.transform.rotation);
            angle += 15;
        }
        angle = 0.0f;
    }
    void ToxicCloud()
    {
        Instantiate(toxicEmmiter, thePlayer.position, thePlayer.rotation);
    }
    void SiphonShot()
    {
        Instantiate(siphonShot, thePlayer.position, thePlayer.rotation);
    }
}
