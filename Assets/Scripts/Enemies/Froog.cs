using UnityEngine;
using System.Collections;

public class Froog : MonoBehaviour
{
    [SerializeField]
    Sprite[] froogs;
    [SerializeField]
    GameObject tongue;
    GameObject theTongue;
    GameObject thePlayer;
    public float currHealth;
    public float maxHealth;
    float agroRange;
    bool inRange = false;
    float timer = 0.0f;
    bool caught = false;
    bool intinced = false;
    float distance;
    //varibles for the visual feedback when the enemy takes damage
    Color baseColor;
    bool changeColor;
    float delayColorChanger;
    // Use this for initialization
    void Start()
    {
        baseColor = gameObject.GetComponent<SpriteRenderer>().color;
        changeColor = false;
        delayColorChanger = 0.0f;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        agroRange = 15.0f;
        maxHealth = 2500;
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(theTongue);
        }
        // Damage color
        if (changeColor == true)
        {
            //start the delaytimer and change the enemy's color to red
            delayColorChanger += Time.deltaTime;
            Color newColor = new Color(1.0f, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

            Color baseColor;
            baseColor = new Color(1.0f, 1.0f, 1.0f);

            //after the color is red change the color back to its normal color
            //and change the bool back to false
            if (delayColorChanger >= 0.1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = baseColor;
                delayColorChanger = 0.0f;
                changeColor = false;
            }
        }
        distance = Vector2.Distance(thePlayer.transform.position, transform.position);
        if (distance <= agroRange)
            inRange = true;
        else
            inRange = false;
        if (inRange)
            timer += Time.deltaTime;
        else
            timer = 0.0f;
        if (timer >= 3.0f)
        {
            caught = true;
            GetComponent<SpringJoint2D>().connectedBody = thePlayer.GetComponent<Rigidbody2D>();
            if (!intinced)
            {
                intinced = true;
                theTongue = (GameObject)Instantiate(tongue, transform.position, transform.rotation);
            }
        }
        if (caught)
        {
            theTongue.transform.localScale = new Vector3(theTongue.transform.localScale.x, distance, 1);
            GetComponent<SpringJoint2D>().frequency += 0.01f;
        }
        if (distance <= 1.5f)
        {
            gameObject.GetComponent<Animator>().SetBool("explode", true);

        }
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        Vector3 fPos = transform.position;
        Vector3 pPos = thePlayer.transform.position;
        if ((int)fPos.x == (int)pPos.x && (int)pPos.y > (int)fPos.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[0];
            theTongue.transform.localScale = new Vector3(1, distance, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[0];
        }
        else if ((int)pPos.x > (int)fPos.x && (int)pPos.y > (int)fPos.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[1];
            theTongue.transform.localScale = new Vector3(distance / 2, distance / 2, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[1];
            //theTongue.transform.rotation = Quaternion.AngleAxis(Vector3.Angle(fPos, pPos)*Mathf.Rad2Deg, Vector3.back);
        }
        else if ((int)pPos.x > (int)fPos.x && (int)pPos.y == (int)fPos.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[2];
            theTongue.transform.localScale = new Vector3(distance, 1, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[2];

        }
        else if ((int)pPos.x > (int)fPos.x && (int)pPos.y < (int)fPos.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[3];
            theTongue.transform.localScale = new Vector3(distance / 2, distance / 2, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[3];
        }
        else if ((int)pPos.x == (int)fPos.x && (int)pPos.y < (int)fPos.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[4];
            theTongue.transform.localScale = new Vector3(1, distance, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[4];
        }
        else if ((int)pPos.x < (int)fPos.x && (int)pPos.y < (int)fPos.y)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[3];
            theTongue.transform.localScale = new Vector3(-1 * distance / 2, distance / 2, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[3];
        }
        else if ((int)pPos.x < (int)fPos.x && (int)pPos.y == (int)fPos.y)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[2];
            theTongue.transform.localScale = new Vector3(-1 * distance, 1, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[2];
        }
        else if ((int)pPos.x < (int)fPos.x && (int)pPos.y > (int)fPos.y)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gameObject.GetComponent<SpriteRenderer>().sprite = froogs[1];
            theTongue.transform.localScale = new Vector3(-1 * distance / 2, distance / 2, 1);
            theTongue.GetComponent<SpriteRenderer>().sprite = theTongue.GetComponent<tongue>().tongues[1];
        }

    }
    public void RecieveDamage(float _dmg)
    {
        // damageNoise.Play();
        currHealth -= _dmg;
         changeColor = true;

    }
    void BlowTheFuckUp()
    {
        thePlayer.SendMessage("TakePhysicalDamage", 500);
        Destroy(theTongue);
        Destroy(gameObject);
    }
}
