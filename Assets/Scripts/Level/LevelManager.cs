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
        Vector3 spawn;
        _level += 1;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().SetMusic(_level);
        GameObject thePlayer = GameObject.FindWithTag("Player");

        if(_level < 5 && _level > 1)
        {
            spawn = new Vector3(94.5f, 60, 0);
            thePlayer.transform.position = spawn;
        }
        else
        {
            spawn = new Vector3(-190, -20, 0);
            thePlayer.transform.position = spawn;
        }
        
        // Clean up last floor
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("ROOM");
        int roomSize = rooms.Length;

        for(int i = 0; i < roomSize; i++)
        {
            Destroy(rooms[i]);
        }

        GameObject[] theWeapons = GameObject.FindGameObjectsWithTag("Weapon");
        int weaponSize = theWeapons.Length;
    
        for (int i = 0; i < weaponSize; i++)
        {
            if(GameObject.FindWithTag("Player").GetComponent<Player>().gun == theWeapons[i])
            {

            }
            else
                Destroy(theWeapons[i]);
        }

        GameObject[] theRunes = GameObject.FindGameObjectsWithTag("Rune");
        int runeSize = theRunes.Length;

        for (int i = 0; i < runeSize; i++)
        {
            if (GameObject.FindWithTag("Player").GetComponent<Player>().currRune == theRunes[i])
            {

            }
            else
                Destroy(theRunes[i]);
        }

        GameObject[] thePassives = GameObject.FindGameObjectsWithTag("Passive");
        int passiveSize = thePassives.Length;

        for (int i = 0; i < passiveSize; i++)
        {
            
            Destroy(thePassives[i]);
        }

        GameObject[] thePortals = GameObject.FindGameObjectsWithTag("PORTAL");
        int portalSize = thePortals.Length;

        for (int i = 0; i < portalSize; i++)
        {

            Destroy(thePortals[i]);
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

        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().followPlayer = false;

    }
}
