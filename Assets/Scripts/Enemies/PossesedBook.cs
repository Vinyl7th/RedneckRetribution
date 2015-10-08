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
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        maxHealth = 250;
        currHealth = maxHealth;
        SetDash();
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
            Destroy(gameObject);
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
        // changeColor = true;

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
