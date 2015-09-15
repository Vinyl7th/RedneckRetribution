using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

   public void switchToGame()
    {
        Application.LoadLevel("Level_Main");
    }

    public void switchToTutorial()
    {
        Application.LoadLevel("Level_Tutorial");
    }
    public void switchToCredits()
    {
        Application.LoadLevel("Menu_Credits");
    }
    public void switchToHTP()
    {
        Application.LoadLevel("Menu_HowToPlay");
    }
    public void switchToOptions()
    {
        Application.LoadLevel("Menu_Options");
    }


}
