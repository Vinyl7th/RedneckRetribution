using UnityEngine;
using System.Collections;

public class HUD_WeaponDisplay : MonoBehaviour
{

    GameObject thePlayer;

    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetGunSprite();
    }

    void GetGunSprite()
    {
        if (thePlayer.GetComponent<Player>().gun != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = thePlayer.GetComponent<Player>().gun.GetComponent<SpriteRenderer>().sprite;
    }
}
