using UnityEngine;
using System.Collections;

public class Drops : MonoBehaviour {

    // Use this for initialization
    int drop;
    [SerializeField]
    GameObject potion;
    [SerializeField]
    GameObject passive;
    [SerializeField]
    GameObject rune;
    [SerializeField]
    GameObject gun;
	void Start ()
    {
        drop = Random.Range(0, 101);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Drop()
    {
        if(drop <= 60)
        {
            //potion
            Instantiate(potion,gameObject.transform.position,gameObject.transform.rotation);
        }
        else if(drop <= 85)
        {
            //passive
            Instantiate(passive,gameObject.transform.position,gameObject.transform.rotation);
        }
        else if(drop <= 95)
        {
            //rune
            Instantiate(rune,gameObject.transform.position,gameObject.transform.rotation);
        }
        else if (drop <= 100)
        {
            //gun
            Instantiate(gun,gameObject.transform.position,gameObject.transform.rotation);
        }
    }
}
