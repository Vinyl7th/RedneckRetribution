using UnityEngine;
using System.Collections;

public class IceRune : MonoBehaviour
{

    public bool current = false;
    bool active;
    int charges;
    int element;
    Transform thePlayer;
    Vector3 offSet;
    public GameObject iceAura;
    float timer = 0.0f;



    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        element = 2;
        charges = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            transform.position = thePlayer.position;
        }
            timer += Time.deltaTime;
        if (charges == 0)
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
    }
    public void OnUse()
    {
        IceAura();

        charges--;
    }
    public void ChangeCurrent()
    {
        if (current)
            current = false;
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetElement(element);
            current = true;
        }

    }
    void IceAura()
    {
        active = true;
    }
}
