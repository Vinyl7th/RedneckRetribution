using UnityEngine;
using System.Collections;

public class FireRune : MonoBehaviour
{
    public bool current = false;
    int charges;
    int element;
    Transform thePlayer;
    Vector3 offSet;
    public GameObject orbitingFire;
   
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        element = 1;
        charges = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
            transform.position = thePlayer.position;
        if (charges == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RuneDestroyed();
            Destroy(gameObject);
        }
    }
    public void OnUse()
    {
        Orbitingfire();
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
    
    void Orbitingfire()
    {
        offSet.y = thePlayer.position.y + 2;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        offSet.y = thePlayer.position.y - 2;
        offSet.x = thePlayer.position.x - 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        offSet.x = thePlayer.position.x + 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        charges--;
    }
 
}
