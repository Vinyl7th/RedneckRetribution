using UnityEngine;
using System.Collections;

public class IceAura : MonoBehaviour
{

    float deathTime;
    float duration = 0.0f;

    Rigidbody2D theRigidBody;
    float x;
    float y;
    float offsetx;
    float offsety;
    // Use this for initialization
    void Start()
    {
        
        // randomize particle duration
            deathTime = 0.1f;

        theRigidBody = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y;
        Vector3 temp = Vector3.forward;
       
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .25f);
        offsetx = Random.Range(-8.0f, 8.0f);
        offsety = Random.Range(-8.0f, 8.0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x += .05f * offsetx;
        y += .05f * offsety;
        theRigidBody.MovePosition(new Vector2(x, y));

        duration += Time.deltaTime;
        if (duration >= deathTime)
        {
            Destroy(gameObject);
        }


    }
}
