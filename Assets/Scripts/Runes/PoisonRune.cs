using UnityEngine;
using System.Collections;

public class PoisonRune : MonoBehaviour {

    public bool current = false;
   
    int charges;
    int element;
    Transform thePlayer;
    public GameObject swordsDance;
    
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
            transform.position = thePlayer.position;
        }
        if (charges == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RuneDestroyed();
            Destroy(gameObject);
        }
     
    }
    public void OnUse()
    {
        SwordsDance();

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
    void SwordsDance()
    {
        for (int i = 0; i < 30; i++)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Instantiate(swordsDance, gameObject.transform.position, gameObject.transform.rotation);
            angle += 15;
        }
        angle = 0.0f;
    }
}
