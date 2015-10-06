using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{
  
    [SerializeField]
    GameObject rain;
    float offsetX;
    float offsetY;
    Vector3 position;
    // Use this for initialization
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        position = Camera.main.transform.position;
        position.z = 1;
        offsetX = Random.Range(-16.0f, 16.0f);
        offsetY = Random.Range(-10.0f, 10.0f);
        position.x += offsetX;
        position.y += offsetY;
        Instantiate(rain, position, rain.transform.rotation);
    }
}
