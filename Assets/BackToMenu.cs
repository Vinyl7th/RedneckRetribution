using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {
    [SerializeField]
    AudioSource src;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    IEnumerator DelayedLoad()
    {
        //Play the clip once
        src.Play();

        //Wait until clip finish playing
        yield return new WaitForSeconds(0.3f);

        //Load scene here
        Application.LoadLevel("Menu_Main");

    }



    public void backToMenu()
    {
        StartCoroutine(DelayedLoad());
    }
}
