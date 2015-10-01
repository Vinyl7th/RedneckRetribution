using UnityEngine;
using System.Collections;




public class BulletEmmiter : MonoBehaviour
{
    [SerializeField]
    Sprite[] theSprites;

    [SerializeField]
    Sprite[] particles;
    public GameObject particle;
    float timer;
    float rand;
    // Use this for initialization
    void Start()
    {
        rand = Random.Range(0.15f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rand)
        {

            if (theSprites[1] == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                particle.GetComponent<SpriteRenderer>().sprite = particles[0];
                particle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.60f);

                Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation); 
                
            }

            if (theSprites[2] == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                particle.GetComponent<SpriteRenderer>().sprite = particles[1];
                particle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.60f);

                Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);

            }
            if (theSprites[3] == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                particle.GetComponent<SpriteRenderer>().sprite = particles[2];
                particle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.30f);

                Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);

            }
            if (theSprites[4] == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                particle.GetComponent<SpriteRenderer>().sprite = particles[3];
                particle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.60f);

                Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);

            }
            timer = 0.0f;
        }
    }
}
