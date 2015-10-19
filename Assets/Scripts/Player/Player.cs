using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
   public float moveSpeed = 8;
    public int elementalType = 0;
    Vector2 moveVelocity;
    Animator theAnimator;

    public bool standingOnObject;
    public GameObject gun;
    public GameObject currRune = null;
    GameObject C_Object;
    bool phoenixEgg;
    bool change;
    float increase;
    bool isSlow;
    float slower;
    GameObject reticule;
    Vector3 pos;
    Vector3 telepos;


    float timmer = 0f;
    // Use this for initialization
    void Start()
    {
        telepos = new Vector3(-150f, -100f, transform.position.z);
        pos = transform.position;
        transform.position = telepos;
        theAnimator = gameObject.GetComponent<Animator>();
        reticule = GameObject.FindGameObjectWithTag("Reticule");
        transform.position = pos;
        //Vector3 newStart = new Vector3(0, 0, 0);
        //gameObject.transform.position = newStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerStats>().pHealthCurr <= 0)
        {
            if (!phoenixEgg)
            {
               
                
                Cursor.visible = true;
                Camera.main.transform.position = new Vector3(-136f, 103f, -10);
                timmer += Time.deltaTime;
                if (timmer >= 3f)
                {
                    Destroy(gameObject);
                    Application.LoadLevel("Menu_Main");
                }
            }
            else
            {
                GetComponent<PlayerStats>().pHealthCurr = GetComponent<PlayerStats>().pHealthMax;
                Destroy(currRune);
                phoenixEgg = false;
            }
        }

        moveVelocity = new Vector2(0, 0);
        increase = moveSpeed * GetComponent<PlayerStats>().pMoveSpeed;

        if(isSlow)
        {
            slower += Time.deltaTime;
        }
        if(slower >= 5.0f)
        {
            moveSpeed = 8;
            isSlow = false;
        }
        if (!change)
        {

            if (Input.GetButton("MoveUp"))
            {
                moveVelocity.y = moveSpeed + increase;
                theAnimator.SetBool("walkRight", true);
            }
            if (Input.GetButton("MoveDown"))
            {
                moveVelocity.y = -moveSpeed - increase;
                theAnimator.SetBool("walkRight", true);
            }
            if (Input.GetButton("MoveLeft"))
            {
                moveVelocity.x = -moveSpeed - increase;
                theAnimator.transform.localScale = new Vector3(-1, 1, 1);
                theAnimator.SetBool("walkRight", true);

            }
            if (Input.GetButton("MoveRight"))
            {
                moveVelocity.x = moveSpeed + increase;
                theAnimator.transform.localScale = new Vector3(1, 1, 1);
                theAnimator.SetBool("walkRight", true);
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = moveVelocity;

            if (reticule.transform.position.x >= transform.position.x)
                theAnimator.transform.localScale = new Vector3(1, 1, 1);
            else
                theAnimator.transform.localScale = new Vector3(-1, 1, 1);
            if (Input.GetButton("Fire1"))
            {
                if (gun)
                {
                    gun.SendMessage("ShootGun", elementalType);


                }
            }
            else
            {
                if (gun)
                    gun.SendMessage("StopAudio");
            }




            if (Input.GetButtonDown("Use"))
            {
                if (currRune)
                    currRune.SendMessage("OnUse");
            }
            if (Input.GetButtonDown("PickUP"))
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
        else
        {
            GetComponent<Rigidbody2D>().velocity = GameObject.FindGameObjectWithTag("Demon").GetComponent<Demon>().moveVelocity;
            transform.position = GameObject.FindGameObjectWithTag("Demon").transform.position;
        }

        SendRuneCharges();
        if (moveVelocity.x == 0 && moveVelocity.y == 0)
        {
            //theAnimator.transform.localScale = new Vector3(-1, 1, 1);
            theAnimator.SetBool("walkRight", false);
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

    public void SendRuneCharges()
    {
        if (elementalType == 1)
        {
            GameObject temp = GameObject.FindWithTag("Flavor");
            temp.GetComponent<FlavorText>().hCharges.text = currRune.GetComponent<FireRune>().charges.ToString();
        }

        if (elementalType == 2)
        {
            GameObject temp = GameObject.FindWithTag("Flavor");
            temp.GetComponent<FlavorText>().hCharges.text = currRune.GetComponent<IceRune>().charges.ToString();
        }

        if (elementalType == 3)
        {
            GameObject temp = GameObject.FindWithTag("Flavor");
            temp.GetComponent<FlavorText>().hCharges.text = currRune.GetComponent<PoisonRune>().charges.ToString();
        }
    }
    public void Change()
    {
        if (change)
        {
            change = false;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            if (gun)
                gun.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            transform.position = GameObject.FindGameObjectWithTag("Demon").transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            if (gun)
                gun.GetComponent<SpriteRenderer>().enabled = false;
            change = true;
        }
    }
    public void Slow()
    {
        if(moveSpeed >= 4)
        {
        isSlow = true;
        slower = 0;
        moveSpeed = moveSpeed - moveSpeed * 0.15f;
        }
    }
}
