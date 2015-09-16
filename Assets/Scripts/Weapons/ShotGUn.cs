using UnityEngine;
using System.Collections;

public class ShotGUn : MonoBehaviour
{
    public GameObject bullet;
    Transform thePlayer;
    Transform Reticule;
    Vector3 Rec_pos;
    Vector3 pos;
    float angle;
    float fireRate = 0.0f;
    int element;
    bool isRight;
    public bool currWeapon = false;
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        Reticule = GameObject.FindGameObjectWithTag("Reticule").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (currWeapon)
            MoveGun();
        fireRate += Time.deltaTime;
        element = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().elementalType;

    }
    void MoveGun()
    {
        Rec_pos = Reticule.position;
        pos = transform.position;
        Rec_pos.x = Rec_pos.x - pos.x;
        Rec_pos.y = Rec_pos.y - pos.y;
        Rec_pos.z = 2.0f;
        angle = Mathf.Atan2(-Rec_pos.y, -Rec_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Set gun to layer above player
        Vector3 newPosition = thePlayer.transform.position;
        newPosition.z = -1.0f;
        transform.position = newPosition;

        if (Reticule.transform.position.x > thePlayer.transform.position.x)
        {
            if (!isRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.y = -1;
                transform.localScale = curScale;
                isRight = true;
            }
            else
                isRight = false;
        }
        else
        {
            if (!isRight)
            {
                Vector3 curScale = transform.localScale;
                curScale.y = 1;
                transform.localScale = curScale;
                isRight = true;
            }
            else
                isRight = false;
        }
    }
    public void ChangeCurrent()
    {
        if (currWeapon)
            currWeapon = false;
        else
            currWeapon = true;
    }
    void ShootGun(int type)
    {

        if (fireRate >= 0.5f)
        {
            switch (element)
            {
                case 0:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(.90f, .90f, .90f);
                    break;
                case 1:
                    bullet.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0, 0);
                    break;
            }
            for (int i = 0; i < 15; i++)
            {
                Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);

            }
            fireRate = 0;
        }

    }

}