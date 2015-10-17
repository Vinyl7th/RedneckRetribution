using UnityEngine;
using System.Collections;

public class TextSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SpawnTheText(int _damage, Vector3 _pos)
    {
        GameObject damageTextObj = (GameObject)Resources.Load("DamageTextPrefab", typeof(GameObject));
        Vector3 newPos = gameObject.transform.position;
        newPos.z = -9;
        GameObject temp = Instantiate(damageTextObj, newPos, gameObject.transform.rotation) as GameObject;

        temp.GetComponent<Damage_Text>().SetValue((int)_damage, _pos);
    }
}
