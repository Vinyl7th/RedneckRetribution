using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Loop()
    {
        GetComponent<Animator>().SetBool("Loop", true);
    }
    void OnTriggerEnter2D(Collider2D hi)
    {
        if (hi.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("LevelManager").SendMessage("LoadLevel");
            Destroy(gameObject);
        }
    }
}
