using UnityEngine;
using System.Collections;

public class Credtis_Scroller : MonoBehaviour {

    public float scrollSpeed;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += (Time.deltaTime * scrollSpeed);
        gameObject.transform.position = pos;
	}
}
