using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OptionsScript : MonoBehaviour {

    [SerializeField]
    public static float sfxVolume = soundController.sfxValue;
    [SerializeField]
    public static float musicVolume = soundController.musicValue;
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
        //gameObject.GetComponent<AudioSource>().Play();
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(1024, 768, true);
            Cursor.visible = false;
            
        }
        else
            Screen.SetResolution(1024, 768, false);
        {
            Cursor.visible = false;
        }

        Cursor.visible = true;
    }


    public void SaveFile()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetInt("hassaved", 1);
        Debug.Log("button pressed");
    }

}
