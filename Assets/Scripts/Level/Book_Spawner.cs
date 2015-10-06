using UnityEngine;
using System.Collections;

public class Book_Spawner : MonoBehaviour {

    bool bossTrigger = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && bossTrigger == false)
        {
            GameObject book = GameObject.FindWithTag("Necronomicon");
            book.SendMessage("ActivateIt");
        }
    }
}
