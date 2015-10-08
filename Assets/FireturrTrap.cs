using UnityEngine;
using System.Collections;

public class FireturrTrap : MonoBehaviour {
    float delaytime;
    public GameObject FireBall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        delaytime += Time.deltaTime;
        if (delaytime >= 1)
        {
            Instantiate(FireBall, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(FireBall, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            Instantiate(FireBall, gameObject.transform.position, Quaternion.Euler(0, 0, 180));
            Instantiate(FireBall, gameObject.transform.position, Quaternion.Euler(0, 0, 270));
            delaytime = 0;
        }

    }
}
