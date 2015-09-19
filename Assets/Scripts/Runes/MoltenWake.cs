using UnityEngine;
using System.Collections;

public class MoltenWake : MonoBehaviour
{

    float timer = 3;
    float test = 2;
    Color change;
    // Damage to send to enemies colliding with this
    public int FireDamage = 20;

    // Use this for initialization
    void Start()
    {
        change = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= test)
        {
            change = new Color(change.r, change.g, change.b, test / 10);
            GetComponent<SpriteRenderer>().color = change;
            test--;
        }
        if (timer <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("TakeDamage", FireDamage);
        }
    }
}
