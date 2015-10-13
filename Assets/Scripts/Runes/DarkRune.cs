using UnityEngine;
using System.Collections;

public class DarkRune : MonoBehaviour
{
    public bool current = false;
    GameObject thePlayer;
  public  GameObject specter;
    public GameObject demon;
    int charges;
    int element;
    Vector3 offSet;
    public int tier;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        element = 4;
        charges = 5;
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
        {
            current = false;
            transform.position = GameObject.FindWithTag("Player").transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetElement(element);
            current = true;
        }

    }
    public void OnUse()
    {
        if (tier == 1)
        {
            BloodBonds();
            charges = 1;
        }
        if (tier == 2)
            Specters();
        if(tier == 3)
        {
            Demon();
            charges = 1;
        }
        charges--;

    }
    void BloodBonds()
    {
        thePlayer.GetComponent<PlayerStats>().pHealthMax = thePlayer.GetComponent<PlayerStats>().pHealthMax / 2;
        thePlayer.GetComponent<PlayerStats>().pAttack += 0.5f;
        if (thePlayer.GetComponent<PlayerStats>().pHealthCurr > thePlayer.GetComponent<PlayerStats>().pHealthMax)
            thePlayer.GetComponent<PlayerStats>().pHealthCurr = thePlayer.GetComponent<PlayerStats>().pHealthMax;
    }
    void Specters()
    {
        offSet.y = thePlayer.transform.position.y + 2;
        Instantiate(specter, offSet, thePlayer.transform.rotation);
        offSet.y = thePlayer.transform.position.y - 2;
        offSet.x = thePlayer.transform.position.x - 3;
        Instantiate(specter, offSet, thePlayer.transform.rotation);
        offSet.x = thePlayer.transform.position.x + 3;
        Instantiate(specter, offSet, thePlayer.transform.rotation);
    }
    void Demon()
    {
        Instantiate(demon, thePlayer.transform.position, thePlayer.transform.rotation);
        thePlayer.SendMessage("Change");
    }
}
