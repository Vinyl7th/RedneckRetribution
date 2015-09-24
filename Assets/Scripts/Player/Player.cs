using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 8;
    public int elementalType = 0;
    Vector2 moveVelocity;

    public bool standingOnObject;
    public GameObject gun;
    public GameObject currRune;
    GameObject C_Object;
    bool phoenixEgg;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerStats>().pHealthCurr == 0)
        {
            if (!phoenixEgg)
                Destroy(gameObject);
            else
            {
                GetComponent<PlayerStats>().pHealthCurr = GetComponent<PlayerStats>().pHealthMax;
            }
        }
        moveVelocity = new Vector2(0, 0);
        if (Input.GetButton("MoveUp"))
        {
            moveVelocity.y = moveSpeed;
        }
        if (Input.GetButton("MoveDown"))
        {
            moveVelocity.y = -moveSpeed;
        }
        if (Input.GetButton("MoveLeft"))
        {
            moveVelocity.x = -moveSpeed;
        }
        if (Input.GetButton("MoveRight"))
        {
            moveVelocity.x = moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVelocity;

        if (Input.GetButton("Fire1"))
        {
            if (gun)
            {
                gun.SendMessage("ShootGun", elementalType);
                

            }
        }




        if (Input.GetButtonDown("Use"))
        {
            if (currRune)
                currRune.SendMessage("OnUse");
        }
        if (Input.GetButton("PickUP"))
        {
            if (C_Object)
            {

                if (C_Object.tag == "Weapon")
                {
                    if (gun)
                        gun.SendMessage("ChangeCurrent");
                    C_Object.SendMessage("ChangeCurrent");
                    gun = C_Object;
                    standingOnObject = false;
                    C_Object = null;
                }
                else if (C_Object.tag == "Rune")
                {
                    if (currRune)
                        currRune.SendMessage("ChangeCurrent");
                    C_Object.SendMessage("ChangeCurrent");
                    currRune = C_Object;
                    standingOnObject = false;
                    C_Object = null;
                    //elementalType = currRune.GetComponent<Rune>().GetElement();
                }
            }
        }

    }
    public void SetElement(int _in)
    {
        elementalType = _in;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weapon")
        {

            C_Object = col.gameObject;
        }
        if (col.tag == "Rune")
        {
            C_Object = col.gameObject;
        }
        standingOnObject = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        C_Object = null;
        standingOnObject = false;
    }
    public int GetElement()
    {
        return elementalType;
    }
    public void RuneDestroyed()
    {
        elementalType = 0;
    }
    public void PhoenixEgg()
    {
        if (phoenixEgg)
            phoenixEgg = false;
        else
            phoenixEgg = true;
    }
}
