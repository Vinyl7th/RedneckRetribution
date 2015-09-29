using UnityEngine;
using System.Collections;

public class Loading_Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Application.LoadLevelAsync("Level_Tutorial");
        
    }
}
