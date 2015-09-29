using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadingAnimation : MonoBehaviour {

    [SerializeField]
    Text loadingText;

    int time = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
            
    }

    void FixedUpdate()
    {

        Debug.Log(loadingText.text);

        time++;
        Debug.Log(time);

        //if(time % 3 == 0)
        loadingText.text = "Loading...";

        

        if (loadingText.text == "Loading...")
        {
            //loadingText.text = " ";
            loadingText.text = "Loading";
            //time = 0;
        }
    }
}
