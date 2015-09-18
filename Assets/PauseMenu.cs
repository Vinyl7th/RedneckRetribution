using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


    bool isPaused;

    [SerializeField]
    GameObject pauseMenuCanvas;



	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
	}

    

   public void backToMenu()
    {
        Application.LoadLevel("Menu_Main");
    }

   public void resume()
    {
        isPaused = false;
    }
}
