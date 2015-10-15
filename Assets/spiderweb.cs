using UnityEngine;
using System.Collections;

public class spiderweb : MonoBehaviour {

    GameObject thePlayer;


    Vector3 playerPos;

    public float damage;
    float webSpeed,
           accuracy,
           displayDelay;
    Vector3 direction;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {

        webSpeed = 10;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        accuracy = Random.Range(-0.08f, 0.08f);
        direction = thePlayer.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 8.0f)
            Destroy(gameObject);

        transform.Translate(new Vector3(webSpeed * Time.deltaTime, accuracy, 0));

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("Slow");
            Destroy(gameObject);
        }

        // if (other.gameObject.tag != "Enemy")
        Destroy(gameObject);

    }
}
