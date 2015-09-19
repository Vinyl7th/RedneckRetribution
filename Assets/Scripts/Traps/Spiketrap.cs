using UnityEngine;
using System.Collections;

public class Spiketrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            other.SendMessage("TakePhysicalDamage", 200);

    }



}
