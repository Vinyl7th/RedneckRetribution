using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{

    [SerializeField]
    GameObject rain;
    [SerializeField]
    GameObject snow;
    int effect;
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
        effect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().weatherType;
        if (effect == 0)
        {

        }
        else if (effect == 1)
        {

            for (int i = 0; i < 3; i++)
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
        else if (effect == 2)
        {
            for (int i = 0; i < 3; i++)
            {

                position = Camera.main.transform.position;
                position.z = 1;
                offsetX = Random.Range(-16.0f, 16.0f);
                offsetY = Random.Range(-10.0f, 10.0f);
                position.x += offsetX;
                position.y += offsetY;
                Instantiate(snow, position, rain.transform.rotation);
            }
        }
    }
}

