using UnityEngine;
using System.Collections;

public class ToxicEmmiter : MonoBehaviour
{
    public GameObject toxicCloud;
    
    float timer =0.0f;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(toxicCloud, transform.position, transform.rotation);
        }
        if (timer >= 10.0f)
        {
         
            timer = 0;
        }
        if (timer == 0)
            Destroy(gameObject);
    }
}
