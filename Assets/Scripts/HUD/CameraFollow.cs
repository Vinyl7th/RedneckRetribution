using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    bool loading;
    float delay;
    Vector3 loadingscreen;
    
    // Use this to determine the active weather system. 0 = no weather, 1 = rain, 2 = snow
    public int weatherType;

    public bool followPlayer = false;
    GameObject thePlayer;
    [SerializeField]
    AudioSource src;

	// Use this for initialization
	void Start ()
    {
        
        loading = true;
        loadingscreen = new Vector3(-93.71f, 131.9f, -10);
        transform.position = loadingscreen;
        thePlayer = GameObject.FindWithTag("Player");
        src.volume = soundController.musicValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!loading)
        {
            if (followPlayer)
            {
                Vector3 newCamPos = thePlayer.transform.position;
                newCamPos.z = -10;
                newCamPos.y += 2;
                gameObject.transform.position = newCamPos;
            }
        }
        else
        {
            delay += Time.deltaTime;
            transform.position = loadingscreen;
            if (delay >= 1)
            {
                loading = false;
            }
        }
    }

    public void SetPosition(Vector3 _position)
    {
        if (!loading)
        {
            Vector3 newCamPos = _position;
            newCamPos.z = -10;
            newCamPos.y += 1.5f;
            gameObject.transform.position = newCamPos;
            followPlayer = false;
        }
        else
        {
            delay += Time.deltaTime;
            transform.position = loadingscreen;
            if (delay >= 1)
            {
                loading = false;
            }
        }
     }
    

    public void FollowPlayer()
    {
        followPlayer = true;
    }

    public void SetWeather(int _weatherType)
    {
        weatherType = _weatherType;
    }
}
