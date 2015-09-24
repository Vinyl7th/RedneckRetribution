using UnityEngine;
using System.Collections;

public class AssaltBullet : MonoBehaviour
{
    float bulletSpeed;
    float accuracy;
    float displayDelay = 0.0f;
    public int damage;
    GameObject thePlayer;
    Vector3 playerPos;
    Transform reticule;

    void Start()
    {
        bulletSpeed = 16.0f;
        accuracy = Random.Range(-0.01f, 0.01f);
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playerPos = thePlayer.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        reticule = GameObject.FindGameObjectWithTag("Reticule").transform;
        Vector3 direction = reticule.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    void Update()
    {
        displayDelay += Time.deltaTime;
        transform.Translate(new Vector3(bulletSpeed * Time.deltaTime, accuracy, 0));
        if (displayDelay >= 0.05f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (Vector3.Distance(transform.position, playerPos) >= 25.0f)
            Destroy(gameObject);


    }

    public void SetDamage(int dam)
    {
        damage = dam;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Default")
        {
            Destroy(gameObject);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);

    }

}
