using UnityEngine;
using System.Collections;

public class RoomMatrix : MonoBehaviour {

    public int Row;
    public int Coll;

    [SerializeField]
    GameObject[] Combat_UP_RIGHT;

    [SerializeField]
    GameObject[] Combat_UP_DOWN;

    [SerializeField]
    GameObject[] Combat_UP_LEFT;

    [SerializeField]
    GameObject[] Combat_RIGHT_DOWN;

    [SerializeField]
    GameObject[] Combat_RIGHT_LEFT;

    [SerializeField]
    GameObject[] Combat_DOWN_LEFT;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
