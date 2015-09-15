using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SceneManager : MonoBehaviour
{
    [SerializeField]
    Button[] buttons = new Button[7];
    [SerializeField]
    

    int btnIndex = 0;
    float btnTimer = 0;
    float sounddelay = 2;
    // Use this for initialization
    void Start ()
    {
      
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
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            btnIndex--;
            if (btnIndex < 0)
                btnIndex = 5;
            btnTimer = 0;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            gameObject.GetComponent<AudioSource>().Play();
            buttons[btnIndex].image.color = Color.green;
            ExecuteEvents.Execute(buttons[btnIndex].gameObject, null, ExecuteEvents.submitHandler);
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



  



   public void switchToGame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Level_Main");
    }

    public void switchToTutorial()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Level_Tutorial");
    }
    public void switchToCredits()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Menu_Credits");
    }
    public void switchToHTP()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Menu_HowToPlay");
    }
    public void switchToOptions()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Application.LoadLevel("Menu_Options");
    }


}
