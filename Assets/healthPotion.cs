using UnityEngine;
using System.Collections;

public class healthPotion : MonoBehaviour {
    [SerializeField]
    AudioSource src;
    [SerializeField]
    GameObject thePlayer;
	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.FindWithTag("Player");
        src.volume = soundController.sfxValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            thePlayer.GetComponent<PlayerStats>().pHealthCurr += (thePlayer.GetComponent<PlayerStats>().pHealthMax * 0.05f);
            Destroy(gameObject);
        }
    }
}
