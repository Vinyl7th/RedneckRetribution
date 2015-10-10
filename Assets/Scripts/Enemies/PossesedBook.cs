using UnityEngine;
using System.Collections;

public class PossesedBook : MonoBehaviour
{
    public Vector2 moveToThis;
    GameObject thePlayer;
    float moveSpeed = 5.0f;
    float angle = 0.0f;
    float timer = 0.0f;
    public float currHealth;
    public float maxHealth;

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
        maxHealth = 1250;
        currHealth = maxHealth;
        SetDash();
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
            Destroy(gameObject);
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
        timer += Time.deltaTime;
        angle += 30;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (timer >= 0.5f)
        {
            SetDash();
            timer = 0;
        }
        Dash();
    }
    void SetDash()
    {

        moveToThis = thePlayer.transform.position;

       // moveToThis.x -= (gameObject.transform.position.x - thePlayer.transform.position.x) * 0.5f;
       // moveToThis.y -= (gameObject.transform.position.y - thePlayer.transform.position.y) * 0.5f;
    }
    public void RecieveDamage(float _dmg)
    {
        // damageNoise.Play();
        currHealth -= _dmg;
         changeColor = true;

    }
    void Dash()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToThis, (moveSpeed * 3.0f) * Time.deltaTime);
        if(transform.position == thePlayer.transform.position)
        {
            thePlayer.SendMessage("TakePhysicalDamage", 500);
            Destroy(gameObject);
        }
        //transform.Translate(moveToThis*Time.deltaTime);
    }
}
