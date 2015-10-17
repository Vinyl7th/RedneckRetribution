using UnityEngine;
using System.Collections;

public class BulletParticle : MonoBehaviour {
    Vector3 direction;
    Vector3 playerPosition;
    Vector3 reticulePosition;
    float deathTime;
    float duration = 0.0f;

    // Use this for initialization
    void Start () {
        deathTime = 0.25f;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        reticulePosition = GameObject.FindGameObjectWithTag("Reticule").transform.position;
        direction = (playerPosition - reticulePosition).normalized;
        
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * 5;
        duration += Time.deltaTime;
        if (duration >= deathTime)
        {
            Destroy(gameObject);
        }
    }
}
