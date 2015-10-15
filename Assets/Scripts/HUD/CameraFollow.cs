using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public bool loading;
    float delay;
    Vector3 loadingscreen;
    
    // Use this to determine the active weather system. 0 = no weather, 1 = rain, 2 = snow
    public int weatherType;

    // Use these to setup the floor / boss audio
    public AudioClip Floor1_BGM;
    public AudioClip Floor2_BGM;
    public AudioClip Floor3_BGM;
    public AudioClip Floor4_BGM;
    public AudioClip Floor5_BGM;
    
    public AudioClip Floor1_Boss_BGM;
    public AudioClip Floor2_Boss_BGM;
    public AudioClip Floor3_Boss_BGM;
    public AudioClip Floor4_Boss_BGM;
    public AudioClip Floor5_Boss_BGM;
    
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

    public void SetMusic(int _musicIndex)
    {
        switch(_musicIndex)
        {
            case 1:
                src.clip = Floor1_BGM;
                break;
            case 2:
                src.clip = Floor2_BGM;
                break;
            case 3:
                src.clip = Floor3_BGM;
                break;
            case 4:
                src.clip = Floor4_BGM;
                break;
            case 5:
                src.clip = Floor5_BGM;
                break;
            case 6:
                src.clip = Floor1_Boss_BGM;
                break;
            case 7:
                src.clip = Floor2_Boss_BGM;
                break;
            case 8:
                src.clip = Floor3_Boss_BGM;
                break;
            case 9:
                src.clip = Floor4_Boss_BGM;
                break;
            case 10:
                src.clip = Floor5_Boss_BGM;
                break;
        }

        src.volume = soundController.musicValue;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().clip = src.clip;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
