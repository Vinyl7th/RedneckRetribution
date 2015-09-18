using UnityEngine;
using System.Collections;

public class audioSourceSFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<AudioSource>().volume = soundController.sfxValue;
	}
}
