using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Damage_Text : MonoBehaviour {

    public string damageValue;
    Color textColor = new Color(1, 1, 1);
    bool startDecay = false;
    Vector3 myPos;

    float decayTimer = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startDecay)
        {
            decayTimer += Time.deltaTime;

            if (decayTimer < 2.0f)
            {
                float colorVal = 1.0f - (decayTimer * 0.5f);
                textColor.b = colorVal;
                textColor.g = colorVal;

                gameObject.GetComponent<TextMesh>().color = textColor;
                gameObject.transform.position = myPos;

                myPos.y += (Time.deltaTime * 2.0f);
            }
            else if(decayTimer > 2.0f)
            {
                Destroy(gameObject);
            }

        }
    }

    public void SetValue(int _damage, Vector3 _position)
    {
        decayTimer = 0.0f;
        int damage = 0;
        damage = _damage;
        gameObject.GetComponent<TextMesh>().text = damage.ToString();

        gameObject.GetComponent<TextMesh>().color = textColor;
        startDecay = true;

        myPos = _position;
        gameObject.transform.position = myPos;
       // Debug.Log("FACK");
    }
}
