using UnityEngine;
using System.Collections;

public class PopupTextDisplay : MonoBehaviour
{
    public bool showImage;

	// Use this for initialization
	void Start ()
    {
        showImage = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (showImage)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            showImage = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            showImage = false;
        }
    }
}
