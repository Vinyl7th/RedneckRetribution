using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {
    [SerializeField]
    //AudioSource src;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}







    public void backToMenu()
    {
        // StartCoroutine(DelayedLoad());

        Application.LoadLevel("Menu_Main");
    }
}
