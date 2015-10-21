using UnityEngine;
using System.Collections;

public class Parralax : MonoBehaviour {

    public float scrollSpeed;
    public float theTimer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        if(GameObject.FindWithTag("TheMusic"))
            GameObject.FindWithTag("TheMusic").GetComponent<AudioSource>().mute = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        theTimer += Time.deltaTime;

        if (theTimer <= 73.60f)
        {
            Vector3 pos = gameObject.transform.position;
            pos.x -= (Time.deltaTime * scrollSpeed);
            gameObject.transform.position = pos;
        }
    }
}
