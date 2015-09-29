using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Transform healthBarBorder;
    public Transform healthBarBack;
    public float heightOffset;

    float MaxHealth;
    float CurrHealth;

    int Etype;

    // Use this for initialization
    void Start ()
    {
      
        Etype = gameObject.GetComponentInParent<EnemyID>().EnemyType;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Etype == 1)
        {
            MaxHealth = gameObject.GetComponentInParent<skeleton>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<skeleton>().hitPoints;
        }
        else if (Etype == 2)
        {
            MaxHealth = gameObject.GetComponentInParent<Necromancer>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Necromancer>().hitPoints;
        }
        else if (Etype == 3)
        {
            MaxHealth = gameObject.GetComponentInParent<WastelandBoss>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<WastelandBoss>().hitPoints;
        }
        else if (Etype == 4)
        {
            MaxHealth = gameObject.GetComponentInParent<FakeEnemies>().hpMax;
            CurrHealth = gameObject.GetComponentInParent<FakeEnemies>().hp;
        }
        else if (Etype == 5)
        {
            MaxHealth = gameObject.GetComponentInParent<Witch>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Witch>().hitPoints;
        }
        else if (Etype == 6)
        {
            
                //gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<FireDragon>().active;
                MaxHealth = gameObject.GetComponentInParent<FireDragon>().maxHealth;
                CurrHealth = gameObject.GetComponentInParent<FireDragon>().hitPoints;
            
        }
        else if (Etype == 7)
        {
             
         
               // gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<PoisonDragon>().active;
                MaxHealth = gameObject.GetComponentInParent<PoisonDragon>().maxHealth;
                CurrHealth = gameObject.GetComponentInParent<PoisonDragon>().hitPoints;
            
        }
        else if (Etype == 8)
        {
          
                //gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<IceDragon>().active;
                MaxHealth = gameObject.GetComponentInParent<IceDragon>().maxHealth;
                CurrHealth = gameObject.GetComponentInParent<IceDragon>().hitPoints;
        }
        else if(Etype == 9)
        {
               // gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<DarkDragon>().active;
                MaxHealth = gameObject.GetComponentInParent<DarkDragon>().maxHealth;
                CurrHealth = gameObject.GetComponentInParent<DarkDragon>().hitPoints;
        }
        else if (Etype == 9)
        {
            // gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<DarkDragon>().active;
            MaxHealth = gameObject.GetComponentInParent<Yeti>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Yeti>().hitPoints;
        }


        Vector3 displayPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + heightOffset, -8.0f);
        healthBarBorder.transform.position = displayPos;

        float ratio = CurrHealth / MaxHealth;

        displayPos.z = -7.0f;
        displayPos.x -= (0.5f * (1.0f - ratio));
        healthBarBack.transform.position = displayPos;
        Vector3 scale = new Vector3(1, 1, 1);
        scale.x = ratio;
        healthBarBack.transform.localScale = scale;
    }
}
