using UnityEngine;
using System.Collections;

public class Dragons : MonoBehaviour
{

    int currDragon = -1;
    int id;
   public  GameObject[] theDragons;
    // Use this for initialization
    void Start()
    {
        theDragons = GameObject.FindGameObjectsWithTag("Enemy");
         SwitchDragon();
   }

    // Update is called once per frame
    void Update()
    {
       
    }
   public void SwitchDragon()
    {
        //if(currDragon != 4)
        currDragon++;
        if (currDragon == 4)
            Destroy(gameObject);
        id = theDragons[currDragon].GetComponent<EnemyID>().EnemyType;
        switch (id)
        {
            case 6:
                theDragons[currDragon].GetComponent<FireDragon>().active = true;
               
                break;
            case 7:
                theDragons[currDragon].GetComponent<PoisonDragon>().active = true;
              
                break;
            case 8:
                theDragons[currDragon].GetComponent<IceDragon>().active = true;
               
                break;
            case 9:
                theDragons[currDragon].GetComponent<DarkDragon>().active = true;
               
                break;
        }

    }
}
