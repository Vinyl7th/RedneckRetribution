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
        else if (Etype == 10)
        {
            // gameObject.GetComponent<SpriteRenderer>().enabled = gameObject.GetComponentInParent<DarkDragon>().active;
            MaxHealth = gameObject.GetComponentInParent<Yetis>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Yetis>().hitPoints;
        }
        else if (Etype == 11)
        {
           
            MaxHealth = gameObject.GetComponentInParent<EnchantedArmor>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<EnchantedArmor>().hitPoints;
        }
        else if (Etype == 12)
        {

            MaxHealth = gameObject.GetComponentInParent<Bat>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Bat>().hitPoints;
        }
        else if (Etype == 13)
        {

            MaxHealth = gameObject.GetComponentInParent<Froog>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<Froog>().currHealth;
        }
        else if (Etype == 14)
        {

            MaxHealth = gameObject.GetComponentInParent<PossesedBook>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<PossesedBook>().currHealth;
        }
        else if (Etype == 15)
        {

            MaxHealth = gameObject.GetComponentInParent<SnowMan>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<SnowMan>().currHealth;
        }
        else if (Etype == 16)
        {

            MaxHealth = gameObject.GetComponentInParent<FrostBug>().maxHealth;
            CurrHealth = gameObject.GetComponentInParent<FrostBug>().currHealth;
        }
        else if (Etype == 20)
        {

            MaxHealth = gameObject.GetComponentInParent<Necronomicon>().bHP_Max;
            CurrHealth = gameObject.GetComponentInParent<Necronomicon>().bHP_Curr;
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
