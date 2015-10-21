using UnityEngine;
using System.Collections;

public class Credits_Score : MonoBehaviour {

    public int creditScore;
    public int creditMax;
    public int creditRate;

    public Transform score;
    public Transform maxScore;
    public Transform rate;

	// Use this for initialization
	void Start ()
    {
        creditScore = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    creditRate = (int)(((float)creditScore / (float)creditMax)* 100);

        score.GetComponent<TextMesh>().text = creditScore.ToString();
        maxScore.GetComponent<TextMesh>().text = creditMax.ToString();
        rate.GetComponent<TextMesh>().text = creditRate.ToString();
    }

    public void AddScore()
    {
        creditScore += 1;
    }
}
