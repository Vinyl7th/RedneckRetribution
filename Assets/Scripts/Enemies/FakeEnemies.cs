using UnityEngine;
using System.Collections;

public class FakeEnemies : MonoBehaviour
{
    public float hp = 1000;
    public float hpMax = 1000;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            GameObject.Destroy(gameObject);
    }

    public void RecieveDamage(float _dmg)
    {
        hp -= _dmg;

    }
}
