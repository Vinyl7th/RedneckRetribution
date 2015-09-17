using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OptionsScript : MonoBehaviour {

    [SerializeField]
    static float sfxVolume = 0.0f;
    [SerializeField]
    static float musicVolume = 0.0f;
    [SerializeField]
    Slider sfxSlider = null;
    [SerializeField]
    Slider musicSlider = null;

    bool testSound = false;



	// Use this for initialization
	void Start ()
    {
        sfxSlider.value = soundController.sfxValue;
        musicSlider.value = soundController.musicValue;
    }
	
	// Update is called once per frame
	void Update ()
    {
         soundController.sfxValue = sfxVolume ;
         soundController.musicValue= musicVolume;
    }





    void OnGUI()
    {
        sfxVolume = sfxSlider.value;
        GUI.Label(new Rect(Screen.width / 2 - 50 + 250, Screen.height / 2 - 130 , 100, 30), "SFX: " + (sfxSlider.value * 10).ToString("f0"));
        musicVolume = musicSlider.value;
        GUI.Label(new Rect(Screen.width / 2 - 50 + 250, Screen.height / 2- 80, 100, 30), "Music: " + (musicSlider.value * 10).ToString("f0"));


    }

    public void testNoise()
    {
        if (!testSound)
        {
            gameObject.GetComponent<AudioSource>().Play();
            testSound = true;
            Invoke("ResetSound", 1.0f);
        }

    }

    void ResetSound()
    {
        testSound = false;
    }

    public void FullScreen()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Screen.fullScreen = !Screen.fullScreen;
    }


    void SaveFile()
    {
        PlayerPrefs.SetFloat("sfxVolume", soundController.sfxValue);
        PlayerPrefs.SetFloat("sfxVolume", soundController.musicValue);

    }

}
