using UnityEngine;
using System.Collections;

public class menuMusicScript : MonoBehaviour {
    public static bool isActive = false;
    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(gameObject);
       // gameObject.GetComponent<AudioSource>().enabled = false;
        if (!isActive)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            isActive = true;
            gameObject.GetComponent<AudioSource>().volume = soundController.musicValue;
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Application.loadedLevelName == "Level_Main" || Application.loadedLevelName == "Level_Tutorial")
            Destroy(gameObject);
        gameObject.GetComponent<AudioSource>().volume = soundController.musicValue;

    }
}
