using UnityEngine;
using System.Collections;

public class passiveSpawner : MonoBehaviour {
    Sprite[] sprites = new Sprite[6];
    [SerializeField]
    int passChoice = 0;
    [SerializeField]
    GameObject thePlayer;

    // 0 = health
    // 1 = damage
    // 2 = move speed
    // 3 = defense
    // 4 = lifesteal
    // 5 = attackSpeed

	// Use this for initialization
	void Start ()
    {
        passChoice = Random.Range(0, 5);
        thePlayer = GameObject.FindWithTag("Player");
        switch (passChoice)
        {
            case 0:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 1:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 2:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case 3:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                break;
            case 4:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
                break;
            case 5:
                
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        switch (passChoice)
        {
            case 0:
                thePlayer.SendMessage("addHealth", 100);
               
                break;
            case 1:
                thePlayer.SendMessage("addDamage", 0.05f);
               
                break;
            case 2:
                thePlayer.SendMessage("addMSpeed", 0.5);
             
                break;
            case 3:
                thePlayer.SendMessage("addMSpeed", 0.5);
             
                break;
            case 4:
                thePlayer.SendMessage("addMSpeed", 0.5);
                
                break;
            case 5:
                thePlayer.SendMessage("addMSpeed", 0.5);
               
                break;
        }
    }

}
