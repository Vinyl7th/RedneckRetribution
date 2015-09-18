using UnityEngine;
using System.Collections;

public class Camera_Room_Properties : MonoBehaviour {

    public bool isStatic;

    GameObject theCamera;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (isStatic)
        {
            if (coll.gameObject.tag == "Player")
            {
                theCamera = GameObject.FindWithTag("MainCamera");
                theCamera.SendMessage("SetPosition", gameObject.transform.position);
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player")
            {
                theCamera = GameObject.FindWithTag("MainCamera");
                theCamera.SendMessage("FollowPlayer");
            }
        }
    }

    

}