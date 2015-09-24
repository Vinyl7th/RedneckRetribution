using UnityEngine;
using System.Collections;

public class FireRune : MonoBehaviour
{
    public bool current = false;
    int charges;
    int element;
    Transform thePlayer;
    Vector3 offSet;
    public GameObject orbitingFire;
    public GameObject moltenWake;
    public int tier;
    bool phoenixEgg;


    float firespawnCooldown;
    int firespawned = 0;
    int firemax = 70;
    bool active;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        element = 1;
        charges = 3;
        if (tier == 3)
            phoenixEgg = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
            transform.position = GameObject.FindWithTag("HUDRune").transform.position;
        if (active)
            MoltenWake();
        if (charges == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().RuneDestroyed();
            Destroy(gameObject);
        }
    }
    public void OnUse()
    {
        if (tier == 1)
            Orbitingfire();
        if (tier == 2)
            MoltenWake();
    }
    public void ChangeCurrent()
    {
        if (current)
        {
            current = false;
            if (phoenixEgg)
                thePlayer.SendMessage("PhoenixEgg");
            transform.position = GameObject.FindWithTag("Player").transform.position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetElement(element);
            current = true;
            if (phoenixEgg)
                thePlayer.SendMessage("PhoenixEgg");
        }

    }

    void Orbitingfire()
    {
        offSet.y = thePlayer.position.y + 2;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        offSet.y = thePlayer.position.y - 2;
        offSet.x = thePlayer.position.x - 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        offSet.x = thePlayer.position.x + 3;
        Instantiate(orbitingFire, offSet, thePlayer.rotation);
        charges--;
    }
    void MoltenWake()
    {
        firespawnCooldown += Time.deltaTime;
        active = true;
        if (firespawned == firemax)
        {
            active = false;
            firespawned = 0;
            charges--;
        }
        if (firespawnCooldown >= 0.1f)
        {
            Instantiate(moltenWake, thePlayer.transform.position, thePlayer.transform.rotation);
            firespawned++;
            firespawnCooldown = 0.0f;
        }

    }

}
