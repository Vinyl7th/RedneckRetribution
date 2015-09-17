using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {
    float creditsTimer = 27.0f;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        creditsTimer -= Time.deltaTime;
        Vector3 temp = gameObject.transform.position;
        temp.y += 1;
        gameObject.transform.position = temp;

        if (creditsTimer <= 0)
        {
            Application.LoadLevel("Menu_Main");
        }


    }
}
