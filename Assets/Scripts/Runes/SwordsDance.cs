using UnityEngine;
using System.Collections;

public class SwordsDance : MonoBehaviour
{

    float movementSpeed = 1.0f;
    float damage = 250;
    void Start()
    {
        


    }


    void Update()
    {
      
        transform.Translate( new Vector3(movementSpeed*Time.deltaTime,1,1));

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

   
}
