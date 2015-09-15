using UnityEngine;
using System.Collections;

public class Rune : MonoBehaviour {
    public bool current = false;
    int charges;
    int element;
    Transform thePlayer;
    Vector3 offSet;
    public GameObject orbitingFire;
	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        charges = 3;
        element = 1;
	}
	
	// Update is called once per frame
	void Update ()
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
        offSet.y = thePlayer.position.y + 2;
        Instantiate(orbitingFire,offSet,thePlayer.rotation);
        offSet.y = thePlayer.position.y - 2;
        offSet.x = thePlayer.position.x - 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        offSet.x = thePlayer.position.x + 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        charges--;
    }
    public int GetElement()
    {
        return element;
    }
}
