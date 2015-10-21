using UnityEngine;
using System.Collections;

public class Credit_Target : MonoBehaviour {

    float hitPoints = 1;
    Color yellow = new Color(1, 1, 0, 1);
    bool spin = false;
    bool scored = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hitPoints < 0.0f)
        {
            gameObject.GetComponent<TextMesh>().color = yellow;
        }

        if(spin)
        {
            gameObject.transform.Rotate(new Vector3(1, 0, 0), (Time.deltaTime * 90));

            if(!scored)
            {
                GameObject temp = GameObject.FindWithTag("CreditScoreMarker");
                temp.GetComponent<Credits_Score>().AddScore();
                scored = true;
            }
        }
    }

    public void RecieveDamage(float _dmg)
    {
        hitPoints -= _dmg;
        spin = true;
    }

}
