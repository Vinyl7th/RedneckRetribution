using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{

    GameObject thePlayer;
    public GameObject spikes;
    public bool WeatherEffects = false;

    public int weatherStyle = 0;

    GameObject[] leftSpikes = new GameObject[4];
    GameObject[] rightSpikes = new GameObject[4];
    GameObject[] topSpikes = new GameObject[4];
    GameObject[] bottomSpikes = new GameObject[4];

    public bool LeftSpikes;
    public bool RightSpikes;
    public bool TopSpikes;
    public bool BotSpikes;

    public float bufferTime = 0.0f;
    public int ActiveObjects = 0;

    bool spikesSpawned = false;
    bool stopSpawning = false;

    // Use this for initialization
    void Start()
    {
        stopSpawning = false;
        thePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bufferTime += Time.deltaTime;

        if (bufferTime >= 0.1f)
        {
            GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            ActiveObjects = currentEnemies.Length;

            if (ActiveObjects == 0)
            {
                    DestroySpikes();
            }

            bufferTime = 0.0f;
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        stopSpawning = false;

        if (coll.gameObject.tag == "Player")
        {
            foreach (Transform child in transform)
            {
                if(child.name != "GunSpawner")
                child.SendMessage("Spawn");
            }

            // Set Weather
            if(WeatherEffects)
            {
                GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().weatherType = weatherStyle;
            }
            else
                GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().weatherType = 0;

            Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
            Vector3 roomPos = gameObject.transform.position;

            float leftBound = roomPos.x - 3;
            float rightBound = roomPos.x + 3;
            float upBound = roomPos.y + 3;
            float downBound = roomPos.y - 3;

            // If player is at the bottom of the screen
            if (playerPos.y <= downBound && playerPos.x > leftBound && playerPos.x < rightBound)
            {
                playerPos.y += 1.5f;
                playerPos.x = roomPos.x;

                if (!spikesSpawned)
                    SpawnSpikes();

                thePlayer.gameObject.transform.position = playerPos;
            }

            // If player is at the top of the screen
            if (playerPos.y >= upBound && playerPos.x > leftBound && playerPos.x < rightBound)
            {
                playerPos.y -= 1.5f;
                playerPos.x = roomPos.x;

                if (!spikesSpawned)
                    SpawnSpikes();

                thePlayer.gameObject.transform.position = playerPos;
            }

            // If player is at the right of the screen
            if (playerPos.x >= rightBound && playerPos.y > downBound && playerPos.y < upBound)
            {
                playerPos.x -= 1.5f;
                playerPos.y = roomPos.y;

                if (!spikesSpawned)
                    SpawnSpikes();

                thePlayer.gameObject.transform.position = playerPos;
            }

            // If player is at the right of the screen
            if (playerPos.x <= rightBound && playerPos.y > downBound && playerPos.y < upBound)
            {
                playerPos.x += 1.5f;
                playerPos.y = roomPos.y;

                if (!spikesSpawned)
                    SpawnSpikes();

                thePlayer.transform.position = playerPos;
            }
        }
    }

    void SpawnSpikes()
    {
        if (!stopSpawning)
        {
            // Left Spikes
            Vector3 spikePos = gameObject.transform.position;
            spikePos.x -= 15.5f;
            spikePos.y += 2f;
            spikePos.z = 0.0f;

            for (int i = 0; i < 4; i++)
            {
                leftSpikes[i] = Instantiate(spikes);
                leftSpikes[i].transform.position = spikePos;
                spikePos.y -= 1.0f;
                spikePos.z -= 0.1f;

                if (!LeftSpikes)
                {
                    leftSpikes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            // Right Spikes
            spikePos = gameObject.transform.position;
            spikePos.x += 15.5f;
            spikePos.y += 2f;
            spikePos.z = 0.0f;

            for (int i = 0; i < 4; i++)
            {
                rightSpikes[i] = Instantiate(spikes);
                rightSpikes[i].transform.position = spikePos;
                spikePos.y -= 1.0f;
                spikePos.z -= 0.1f;

                if (!RightSpikes)
                {
                    rightSpikes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            // Top Spikes
            spikePos = gameObject.transform.position;
            spikePos.x -= 1.5f;
            spikePos.y += 9f;
            spikePos.z = 0.0f;

            for (int i = 0; i < 4; i++)
            {
                topSpikes[i] = Instantiate(spikes);
                topSpikes[i].transform.position = spikePos;
                spikePos.x += 1.0f;
                spikePos.z -= 0.1f;

                if (!TopSpikes)
                {
                    topSpikes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            // Bot Spikes
            spikePos = gameObject.transform.position;
            spikePos.x -= 1.5f;
            spikePos.y -= 9f;
            spikePos.z = 0.0f;

            for (int i = 0; i < 4; i++)
            {
                bottomSpikes[i] = Instantiate(spikes);
                bottomSpikes[i].transform.position = spikePos;
                spikePos.x += 1.0f;
                spikePos.z -= 0.1f;

                if (!BotSpikes)
                {
                    bottomSpikes[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    void DestroySpikes()
    {
        GameObject[] theDoors = GameObject.FindGameObjectsWithTag("Door");
        int length = theDoors.Length;
        for(int i = 0; i < length; i++)
        {
            Destroy(theDoors[i]);
        }

        // gameObject.BroadcastMessage("DestroySpawner");
        spikesSpawned = false;
        stopSpawning = true;
    }


}
