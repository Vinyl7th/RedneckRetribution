using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Text currHealth;
    public Text maxHealth;
    public Text attack;
    public Text defense;
    public Text attackSpeed;
    public Text moveSpeed;
    public Text lifesteal;

    GameObject thePlayer;

    // Use this for initialization
    void Start ()
    {
        thePlayer = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        currHealth.text = thePlayer.GetComponent<PlayerStats>().pHealthCurr.ToString();
        maxHealth.text = thePlayer.GetComponent<PlayerStats>().pHealthMax.ToString();
        attack.text = thePlayer.GetComponent<PlayerStats>().pAttack.ToString();
        defense.text = thePlayer.GetComponent<PlayerStats>().pDefense.ToString();
        attackSpeed.text = thePlayer.GetComponent<PlayerStats>().pAttackSpeed.ToString();
        moveSpeed.text = thePlayer.GetComponent<PlayerStats>().pMoveSpeed.ToString();
        lifesteal.text = thePlayer.GetComponent<PlayerStats>().pLifeSteal.ToString();
    }
}
