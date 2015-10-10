using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int _level = 0;
    public bool nextLevel = false;

    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;
    public GameObject Floor5;

    // Use this for initialization
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextLevel)
        {
            LoadLevel();
            nextLevel = false;
        }
    }

    public void LoadLevel()
    {
        _level += 1;
        GameObject thePlayer = GameObject.FindWithTag("Player");
        Vector3 spawn = new Vector3(-200, 0, 0);
        thePlayer.transform.position = spawn;

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("ROOM");
        int roomSize = rooms.Length;

        for(int i = 0; i < roomSize; i++)
        {
            Destroy(rooms[i]);
        }

        switch (_level)
        {
            case 1:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }
            case 2:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }
            case 3:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }
            case 4:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }
            case 5:
                {
                    Instantiate(Floor1, spawn, gameObject.transform.rotation);
                    break;
                }

        }
    }
}
