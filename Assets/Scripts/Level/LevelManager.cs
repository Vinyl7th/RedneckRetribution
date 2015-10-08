using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;
    public GameObject Floor5;

    // Use this for initialization
    void Start()
    {
        LoadLevel(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int _level)
    {
        GameObject thePlayer = GameObject.FindWithTag("Player");
        Vector3 spawn = new Vector3(-200, 0, 0);
        thePlayer.transform.position = spawn;


        switch (_level)
        {
            case 1:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }
            case 2:
                {
                    Instantiate(Floor2, spawn, gameObject.transform.rotation);
                    break;
                }
            case 3:
                {
                    Instantiate(Floor3, spawn, gameObject.transform.rotation);
                    break;
                }
            case 4:
                {
                    Instantiate(Floor4, spawn, gameObject.transform.rotation);
                    break;
                }
            case 5:
                {
                    Instantiate(Floor5, spawn, gameObject.transform.rotation);
                    break;
                }

        }
    }
}
