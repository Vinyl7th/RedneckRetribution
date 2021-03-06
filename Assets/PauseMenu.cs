﻿using UnityEngine;
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
            Time.timeScale = 0.0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //isPaused = !isPaused;
            if(isPaused == true)
            Application.LoadLevel("Menu_Main");
        }
	}

    

   public void backToMenu()
    {
        isPaused = !isPaused;
        Application.LoadLevel("Menu_Main");
        Cursor.visible = true;
    }

   public void resume()
    {
        isPaused = false;
    }
}
