using UnityEngine;
using System.Collections;

public class RoomMatrix : MonoBehaviour {

    public int floorNum;

    [SerializeField]
    int[] Row1;

    [SerializeField]
    int[] Row2;

    [SerializeField]
    int[] Row3;

    [SerializeField]
    int[] Row4;

    [SerializeField]
    int[] Row5;

    [SerializeField]
    int[] Row6;

    [SerializeField]
    int[] Row7;

    // Type 1
    [SerializeField]
    GameObject[] Combat_UP_RIGHT;

    // Type 2
    [SerializeField]
    GameObject[] Combat_UP_DOWN;

    // Type 3
    [SerializeField]
    GameObject[] Combat_UP_LEFT;

    // Type 4
    [SerializeField]
    GameObject[] Combat_RIGHT_DOWN;

    // Type 5
    [SerializeField]
    GameObject[] Combat_RIGHT_LEFT;

    // Type 6
    [SerializeField]
    GameObject[] Combat_DOWN_LEFT;

    // Type 7
    [SerializeField]
    GameObject[] Treasure_UP;

    // Type 8
    [SerializeField]
    GameObject[] Treasure_RIGHT;

    // Type 9
    [SerializeField]
    GameObject[] Treasure_DOWN;

    // Type 10
    [SerializeField]
    GameObject[] Treasure_LEFT;

    // Type 11
    [SerializeField]
    GameObject[] Armory_UP;

    // Type 12
    [SerializeField]
    GameObject[] Armory_RIGHT;

    // Type 13
    [SerializeField]
    GameObject[] Armory_DOWN;

    // Type 14
    [SerializeField]
    GameObject[] Armory_LEFT;
    
    // Type 15
    [SerializeField]
    GameObject[] Combat_NO_UP;

    // Type 16
    [SerializeField]
    GameObject[] Combat_NO_RIGHT;

    // Type 17
    [SerializeField]
    GameObject[] Combat_NO_DOWN;

    // Type 18
    [SerializeField]
    GameObject[] Combat_NO_LEFT;

    public GameObject Start_Room;
    public GameObject Boss_Room;

    // Use this for initialization
    void Start ()
    {
        Vector3 SpawnPosition;
        // Set rooms

        // Set start
        SpawnPosition = new Vector3(0, 0, 0);
        Instantiate(Start_Room, SpawnPosition, gameObject.transform.rotation);

        // Set bottom row
        for (int i = 1; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 0, 0);
            SetRoom(Row1[i], SpawnPosition);
        }

        // Set second row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 20.0f, 0);
            SetRoom(Row2[i], SpawnPosition);
        }

        // Set third row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 40.0f, 0);
            SetRoom(Row3[i], SpawnPosition);
        }

        // Set fourth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 60.0f, 0);
            SetRoom(Row4[i], SpawnPosition);
        }

        // Set fifth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 80.0f, 0);
            SetRoom(Row5[i], SpawnPosition);
        }

        // Set sixth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 100.0f, 0);
            SetRoom(Row6[i], SpawnPosition);
        }

        // Set seventh row
        for (int i = 0; i < 6; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 120.0f, 0);
            SetRoom(Row7[i], SpawnPosition);
        }

        // Set boss room
        SpawnPosition = new Vector3(32.0f * 6.0f, 120.0f, 0);
        Instantiate(Boss_Room, SpawnPosition, gameObject.transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
	   
	}

    void SetRoom(int _roomType, Vector3 _position)
    {
        Vector3 theRotation = new Vector3(0, 0, 0);

        int index = 0;

        // Determine floor patterns by floor number
        // Floor 1 = Forest / Snow
        // Floor 2 = Forest / Snow / Dungeon
        // Floor 3 = Snow / Dungeon / Mansion
        // Floor 4 = Dungeon / Mansion
        if (floorNum == 1)
            index = Random.Range(0, 2);
        else if (floorNum == 2)
            index = Random.Range(0, 3);
        else if (floorNum == 3)
            index = Random.Range(1, 4);
        else if (floorNum == 4)
            index = Random.Range(2, 4);

        switch (_roomType)
        {
            case 0: // No Room
                {
                    break;
                }
            case 1: // Combat_UP_RIGHT
                {
                    Instantiate(Combat_UP_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 2: // Combat_UP_DOWN
                {
                    Instantiate(Combat_UP_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 3: // Combat_UP_LEFT
                {
                    Instantiate(Combat_UP_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 4: // Combat_RIGHT_DOWN
                {
                    Instantiate(Combat_RIGHT_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 5: // Combat_RIGHT_LEFT
                {
                    Instantiate(Combat_RIGHT_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 6: // Combat DOWN LEFT
                {
                    Instantiate(Combat_DOWN_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 7: // Treasure UP
                {
                    Instantiate(Treasure_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 8: // Treasure RIGHT
                {
                    Instantiate(Treasure_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 9: // Treasure DOWN
                {
                    Instantiate(Treasure_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 10: // Treasure LEFT
                {
                    Instantiate(Treasure_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 11: // Armory UP
                {
                    Instantiate(Armory_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 12: // Armory RIGHT
                {
                    Instantiate(Armory_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 13: // Armory DOWN
                {
                    Instantiate(Armory_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 14: // Armory LEFT
                {
                    Instantiate(Armory_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 15: // Combat NO UP
                {
                    Instantiate(Combat_NO_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 16: // Combat NO RIGHT
                {
                    Instantiate(Combat_NO_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 17: // Combat NO DOWN
                {
                    Instantiate(Combat_NO_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 18: // Combat NO LEFT
                {
                    Instantiate(Combat_NO_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
        }
    }
}
