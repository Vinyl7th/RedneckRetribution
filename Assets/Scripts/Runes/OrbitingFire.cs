using UnityEngine;
using System.Collections;

public class OrbitingFire : MonoBehaviour
{
    float timer = 0.0f;
    Transform thePlayer;
    Vector3 position;
   
    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        position = thePlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(position, Vector3.back, 8);
        position = thePlayer.position;
        timer += Time.deltaTime;
        if(timer >= 5.6f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
            col.SendMessage("TakeDamage", 100);
    }
}
