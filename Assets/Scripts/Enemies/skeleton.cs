using UnityEngine;
using System.Collections;

public class skeleton : MonoBehaviour {

    GameObject thePlayer,
               spawnCounter;


    float aggroRange, 
           moveSpeed,
           hitPoints;

	// Use this for initialization
	void Start () {
        // At the start make the thePlayer gameobject the player with tag
        thePlayer = GameObject.FindWithTag("Player");

        // Set the Enemy's Movement Speed, Hitpoints, and aggrorange
        aggroRange = 10.0f;
        moveSpeed = 4.2f;
        hitPoints = 2000.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (hitPoints < 0.0f){
            Destroy(gameObject);
        }

	}
    public void receiveDamage(float _dmg){
        hitPoints -= _dmg;
    }

   void Move() {
        //Set the player movement every frame to 0x 0y
        Vector2 moveEnemy = new Vector2(0,0);

        // tracks the distance to the player's position from the skeleton's position
        float DisToPlayer = Vector2.Distance(
            thePlayer.transform.position, 
            gameObject.transform.position);
        
        //if player's position is with then the range of the skeleton's aggrorange
        if(DisToPlayer <= aggroRange)
        {
            //temp varibles for the player's and enemies's position
            float playerX = thePlayer.transform.position.x;
            float playerY = thePlayer.transform.position.y;
            float enemyX = gameObject.transform.position.x;
            float enemyY = gameObject.transform.position.y;

            if (playerX > enemyX)        // enemy move right
                moveEnemy.x += moveSpeed;
            if (playerX < enemyX)        // enemy move left
                moveEnemy.x -= moveSpeed;
            if (playerY > enemyY)        // enemy move up
                moveEnemy.y += moveSpeed;
            if (playerY < enemyY)        // enemy move down
                moveEnemy.y -= moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveEnemy;
    }

}
