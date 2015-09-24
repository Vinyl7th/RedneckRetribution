using UnityEngine;
using System.Collections;

public class RoomMatrix : MonoBehaviour {

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

    GameObject Start_Room;
    GameObject Boss_Room;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	   
	}

    void SetRoom(int _roomType, Vector3 _position)
    {
        Vector3 theRotation = new Vector3(0, 0, 0);
        switch(_roomType)
        {
            case 0: // No Room
                {
                    break;
                }
            case 1: // Combat_UP_RIGHT
                {
                    int num = Combat_UP_RIGHT.Length;
                    int index = Random.Range(0, num);
                    Instantiate(Combat_UP_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
        }
    }
}
