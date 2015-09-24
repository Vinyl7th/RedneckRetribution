using UnityEngine;
using System.Collections;

public class DarkRune : MonoBehaviour
{
    public bool current = false;
    GameObject thePlayer;
    int charges;
    int element;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        element = 4;
        charges = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            transform.position = GameObject.FindWithTag("HUDRune").transform.position;
        }
        if (charges == 0)
            Destroy(gameObject);
    }
    public void ChangeCurrent()
    {
        if (current)
            current = false;
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetElement(element);
            current = true;
        }

    }
    public void OnUse()
    {
        BloodBonds();
        Specters();
        charges--;
        
    }
    void BloodBonds()
    {
        thePlayer.GetComponent<PlayerStats>().pHealthMax = thePlayer.GetComponent<PlayerStats>().pHealthMax / 2;
        thePlayer.GetComponent<PlayerStats>().pAttack += 0.5f;
        if(thePlayer.GetComponent<PlayerStats>().pHealthCurr > thePlayer.GetComponent<PlayerStats>().pHealthMax)
            thePlayer.GetComponent<PlayerStats>().pHealthCurr = thePlayer.GetComponent<PlayerStats>().pHealthMax;
    }
    void Specters()
    {

    }
}
