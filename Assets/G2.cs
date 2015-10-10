using UnityEngine;
using System.Collections;

public class G2 : MonoBehaviour {

    GameObject thePlayer;


    Vector3 playerPos;

    public float damage;
    float fireballSpeed,
           accuracy,
           displayDelay;
    Vector3 direction;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {

        fireballSpeed = 13;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        accuracy = Random.Range(-0.3f, 0.3f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        direction = thePlayer.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        displayDelay += Time.deltaTime;
        if (displayDelay >= 0.1f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        timer += Time.deltaTime;
        if (timer >= 8.0f)
            Destroy(gameObject);

        transform.Translate(new Vector3(fireballSpeed * Time.deltaTime, accuracy, 0));

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("TakeFireDamage", 150);
            Destroy(gameObject);
        }

        if (other.gameObject.tag != "Enemy")
            Destroy(gameObject);

    }
}
