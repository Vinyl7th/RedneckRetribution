using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SceneManager : MonoBehaviour
{
    [SerializeField]
    Button[] buttons = new Button[7];
    [SerializeField]
    AudioSource src;

    int btnIndex = 0;
    float btnTimer = 0;
    
    // Use this for initialization
    void Start ()
    {

        soundController.sfxValue = PlayerPrefs.GetFloat("sfxVolume");
        soundController.musicValue = PlayerPrefs.GetFloat("musicVolume");
       // Debug.Log(PlayerPrefs.GetFloat("sfxVolume"));
        //Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
        //Debug.Log(src.volume);
        if (soundController.sfxValue == 0f && soundController.musicValue == 0f && PlayerPrefs.GetInt("hassaved") != 1)
        {
            soundController.sfxValue = 0.5f;
            soundController.musicValue = 0.5f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            btnIndex++;
            if (btnIndex > 5)
                btnIndex = 0;
            btnTimer = 0;
            src.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            btnIndex--;
            if (btnIndex < 0)
                btnIndex = 5;
            btnTimer = 0;
            src.Play();
        }
     
        if (Input.GetKeyDown(KeyCode.Return))
        {

           
            buttons[btnIndex].image.color = Color.green;


            StartCoroutine(DelayedLoad());
                    
            
           
        }

        GUI.FocusControl(buttons[btnIndex].name);
        
        for (int i = 0; i < 6; i++)
        {
            buttons[i].image.color = Color.white;
        }
        buttons[btnIndex].image.color = Color.red;

        btnTimer += Time.deltaTime;
        if (btnTimer >= 3)
        {
            btnIndex = 6;
            btnTimer = 0;
        }

       

    }


    IEnumerator DelayedLoad()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.4f);

        //Load scene here
        ExecuteEvents.Execute(buttons[btnIndex].gameObject, null, ExecuteEvents.submitHandler);

    }

    IEnumerator DelayedLoad1()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.3f);

        //Load scene here
        Application.Quit();

    }

    IEnumerator DelayedLoad2()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.3f);

        //Load scene here
        Application.LoadLevel("Level_Main");

    }
    IEnumerator DelayedLoad3()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.4f);

        //Load scene here
        Application.LoadLevel("Level_Tutorial");

    }
    IEnumerator DelayedLoad4()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.4f);

        //Load scene here
        Application.LoadLevel("Menu_Credits");

    }
    IEnumerator DelayedLoad5()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.4f);

        //Load scene here
        Application.LoadLevel("Menu_HowToPlay");

    }
    IEnumerator DelayedLoad6()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.4f);

        //Load scene here
        Application.LoadLevel("Menu_Options");

    }

    public void switchToGame()
    {
        StartCoroutine(DelayedLoad2());
       
    }

    public void switchToTutorial()
    {
        StartCoroutine(DelayedLoad3());
        
    }
    public void switchToCredits()
    {
        StartCoroutine(DelayedLoad4());
       
    }
    public void switchToHTP()
    {
        StartCoroutine(DelayedLoad5());
        
    }
    public void switchToOptions()
    {
        StartCoroutine(DelayedLoad6());
       
    }

    public void ExitGame()
    {
        StartCoroutine(DelayedLoad1());
        
    }
}
