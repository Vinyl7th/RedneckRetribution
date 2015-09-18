using UnityEngine;
using System.Collections;

public class soundController : MonoBehaviour {
    public static float sfxValue = PlayerPrefs.GetFloat("sfxVolume");
    public static float musicValue = PlayerPrefs.GetFloat("musicVolume");
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        sfxValue = OptionsScript.sfxVolume;
        musicValue = OptionsScript.musicVolume;
        //Debug.Log(OptionsScript.sfxVolume);
        //Debug.Log(OptionsScript.sfxVolume);
    }
	
	// Update is called once per frame
	void Update ()
    {
        sfxValue = OptionsScript.sfxVolume;
        musicValue = OptionsScript.musicVolume;
	}
}
