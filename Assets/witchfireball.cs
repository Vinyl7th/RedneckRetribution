using UnityEngine;
using System.Collections;

public class witchfireball : MonoBehaviour {
    GameObject thePlayer;


    Vector3 playerPos;

    public float damage;
    float fireballSpeed;
    float selfDestroy;
 
    Vector3 direction;

    

    // Use this for initialization
    void Start()
    {

        fireballSpeed = 6;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
      

    }

    // Update is called once per frame
    void Update()
    {
        selfDestroy += Time.deltaTime;
        float _Speed = fireballSpeed * Time.deltaTime;
         transform.position = Vector2.MoveTowards(gameObject.transform.position, thePlayer.transform.position, _Speed);

        if (selfDestroy >= 2.0f)
            Destroy(gameObject);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("TakeFireDamage", 75);
            Destroy(gameObject);
        }

      

    }
}
