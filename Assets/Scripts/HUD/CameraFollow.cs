using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public bool followPlayer = false;
    GameObject thePlayer;
    [SerializeField]
    AudioSource src;
	// Use this for initialization
	void Start ()
    {
        thePlayer = GameObject.FindWithTag("Player");
        src.volume = soundController.musicValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (followPlayer)
        {
            Vector3 newCamPos = thePlayer.transform.position;
            newCamPos.z = -10;
            newCamPos.y += 2;
            gameObject.transform.position = newCamPos;
        }
	}

    public void SetPosition(Vector3 _position)
    {
        Vector3 newCamPos = _position;
        newCamPos.z = -10;
        newCamPos.y += 1.5f;
        gameObject.transform.position = newCamPos;
        followPlayer = false;
    }

    public void FollowPlayer()
    {
        followPlayer = true;
    }
}
