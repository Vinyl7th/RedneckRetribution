using UnityEngine;
using System.Collections;

public class RoomMatrix : MonoBehaviour {

    struct PreRoom
    {
        // State of the room in pre-pro
        // 0 = open 1 = available 2 = complete
        public int roomState;

        // State of the available doors in each room. 0 = no data, 1 = door, 2 = no door
        public int up;
        public int right;
        public int down;
        public int left;

        // Room style
        public int style;

        // Location in the vector
        public Vector2 pos;
    }

    public int ArraySize;

    public int theUp;
    public int theRight;
    public int theDown;
    public int theLeft;

    PreRoom[,] roomLayout;
    Vector2[] availableRooms;
    PreRoom[] validRooms;
    public Vector2 bossCoords;

    public int floorNum;

    public int[] Row1;
    public int[] Row2;
    public int[] Row3;
    public int[] Row4;
    public int[] Row5;
    public int[] Row6;
    public int[] Row7;

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

    // Type 21
    [SerializeField]
    GameObject[] Combat_ALL;

    public GameObject Start_Room;

    [SerializeField]
    public GameObject[] Boss_Room;

    // Use this for initialization
    void Start()
    {
        Row1 = new int[7];
        Row2 = new int[7];
        Row3 = new int[7];
        Row4 = new int[7];
        Row5 = new int[7];
        Row6 = new int[7];
        Row7 = new int[7];

        floorNum = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>()._level;

        Vector3 SpawnPosition;
        // Set rooms

        LetsDoThis();

        ForceValidation();
        EmbedMatrix();

        // Set start
        SpawnPosition = new Vector3(0, 0, 0);

        // Set bottom row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 0, 0);
            SetRoom(Row1[i], SpawnPosition);
        }

        // Set second row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 20.0f, 0);
            SetRoom(Row2[i], SpawnPosition);
        }

        // Set third row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 40.0f, 0);
            SetRoom(Row3[i], SpawnPosition);
        }

        // Set fourth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 60.0f, 0);
            SetRoom(Row4[i], SpawnPosition);
        }

        // Set fifth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 80.0f, 0);
            SetRoom(Row5[i], SpawnPosition);
        }

        // Set sixth row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 100.0f, 0);
            SetRoom(Row6[i], SpawnPosition);
        }

        // Set seventh row
        for (int i = 0; i < 7; i++)
        {
            SpawnPosition = new Vector3(32.0f * (float)i, 120.0f, 0);
            SetRoom(Row7[i], SpawnPosition);
        }

        // Set boss room
        SpawnPosition = new Vector3(32.0f * 6.0f, 120.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Good
    void SetRoom(int _roomType, Vector3 _position)
    {
        Vector3 theRotation = new Vector3(0, 0, 0);

        int index = 0;

        // Determine floor patterns by floor number
        // Floor 1 = Forest / Snow
        // Floor 2 = Forest / Snow / Dungeon
        // Floor 3 = Snow / Dungeon / Mansion
        // Floor 4 = Dungeon / Mansion
        if (floorNum == 1)
            index = Random.Range(0, 2);
        else if (floorNum == 2)
            index = Random.Range(0, 3);
        else if (floorNum == 3)
            index = Random.Range(1, 4);
        else if (floorNum == 4)
            index = Random.Range(2, 4);

        switch (_roomType)
        {
            case 0: // No Room
                {
                    break;
                }
            case 1: // Combat_UP_RIGHT
                {
                    Instantiate(Combat_UP_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 2: // Combat_UP_DOWN
                {
                    Instantiate(Combat_UP_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 3: // Combat_UP_LEFT
                {
                    Instantiate(Combat_UP_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 4: // Combat_RIGHT_DOWN
                {
                    Instantiate(Combat_RIGHT_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 5: // Combat_RIGHT_LEFT
                {
                    Instantiate(Combat_RIGHT_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 6: // Combat DOWN LEFT
                {
                    Instantiate(Combat_DOWN_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 7: // Treasure UP
                {
                    Instantiate(Treasure_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 8: // Treasure RIGHT
                {
                    Instantiate(Treasure_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 9: // Treasure DOWN
                {
                    Instantiate(Treasure_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 10: // Treasure LEFT
                {
                    Instantiate(Treasure_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 11: // Armory UP
                {
                    Instantiate(Armory_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 12: // Armory RIGHT
                {
                    Instantiate(Armory_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 13: // Armory DOWN
                {
                    Instantiate(Armory_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 14: // Armory LEFT
                {
                    Instantiate(Armory_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 15: // Combat NO UP
                {
                    Instantiate(Combat_NO_UP[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 16: // Combat NO RIGHT
                {
                    Instantiate(Combat_NO_RIGHT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 17: // Combat NO DOWN
                {
                    Instantiate(Combat_NO_DOWN[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 18: // Combat NO LEFT
                {
                    Instantiate(Combat_NO_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
            case 19: // Combat NO LEFT
                {
                    Instantiate(Start_Room, _position, gameObject.transform.rotation);
                    break;
                }
            case 20: // Combat NO LEFT
                {
                    Instantiate(Boss_Room[floorNum], _position, gameObject.transform.rotation);
                    break;
                }
            case 21: // Combat NO LEFT
                {
                    Instantiate(Combat_NO_LEFT[index], _position, gameObject.transform.rotation);
                    break;
                }
        }
    }

    // Good
    public void RandomizeLayout()
    {
        roomLayout = new PreRoom[9, 9];

        // Set the rooms to 0, set the borders to full
        InitializeRooms();

        // Set up Start room
        roomLayout[4, 4].up = 0;
        roomLayout[4, 4].right = 1;
        roomLayout[4, 4].down = 1;
        roomLayout[4, 4].left = 1;

        roomLayout[4, 4].roomState = 2;

        // Set up Adjacent rooms
        roomLayout[4, 5].down = 1;
        roomLayout[4, 5].roomState = 1;

        roomLayout[5, 4].left = 1;
        roomLayout[5, 4].roomState = 1;

        roomLayout[4, 3].up = 1;
        roomLayout[4, 3].roomState = 1;

        roomLayout[3, 4].right = 1;
        roomLayout[3, 4].roomState = 1;


    }

    // Good
    void InitializeRooms()
    {
        int x = 0;
        int y = 0;

        for (; x < 9; x++)
        {
            for (; y < 9; y++)
            {
                roomLayout[x, y].roomState = 0;

                roomLayout[x, y].up = 0;
                roomLayout[x, y].right = 0;
                roomLayout[x, y].down = 0;
                roomLayout[x, y].left = 0;

                roomLayout[x, y].style = 0;
                roomLayout[x, y].pos = new Vector2(x, y);
            }
        }

        //***********************//
        // Set outlines as empty //
        //***********************//

        // Set bottom row empty
        x = 0;
        y = 0;

        for (; x < 9; x++)
        {
            roomLayout[x, y].roomState = 2;

            roomLayout[x, y].up = 2;
            roomLayout[x, y].right = 2;
            roomLayout[x, y].down = 2;
            roomLayout[x, y].left = 2;

            int tempY = y + 1;
            roomLayout[x, tempY].down = 2;
            
            roomLayout[x, y].style = 0;
        }

        // Set top row empty
        x = 0;
        y = 8;
        for (; x < 9; x++)
        {
            roomLayout[x, y].roomState = 2;

            roomLayout[x, y].up = 2;
            roomLayout[x, y].right = 2;
            roomLayout[x, y].down = 2;
            roomLayout[x, y].left = 2;

            int tempY = y - 1;
            roomLayout[x, tempY].up = 2;

            roomLayout[x, y].style = 0;
        }

        // Set left row empty
        x = 0;
        y = 0;
        for (; y < 9; y++)
        {
            roomLayout[x, y].roomState = 2;

            roomLayout[x, y].up = 2;
            roomLayout[x, y].right = 2;
            roomLayout[x, y].down = 2;
            roomLayout[x, y].left = 2;

            int tempX = x + 1;
            roomLayout[tempX, y].left = 2;

            roomLayout[x, y].style = 0;
        }

        // Set right row empty
        x = 8;
        y = 0;
        for (; y < 9; y++)
        {
            roomLayout[x, y].roomState = 2;

            roomLayout[x, y].up = 2;
            roomLayout[x, y].right = 2;
            roomLayout[x, y].down = 2;
            roomLayout[x, y].left = 2;

            int tempX = x - 1;
            roomLayout[tempX, y].right = 2;

            roomLayout[x, y].style = 0;
        }

    }

    void FindValidRooms()
    {
        // Check every room for rooms that are valid
        int numRooms = 0;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (roomLayout[i, j].roomState == 1)
                    numRooms++;
            }
        }

        // Create vector the size of the number of valid rooms
        availableRooms = new Vector2[numRooms];
        int index = 0;

        // Get the matrix position of every valid room
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (roomLayout[i, j].roomState == 1)
                {
                    Vector2 newPos;
                    newPos.x = i;
                    newPos.y = j;
                    availableRooms[index] = newPos;
                    roomLayout[i, j].pos = newPos;
                    index++;
                }
            }
        }


    }

    bool LetsDoThis()
    {
        bool bossFound = false;

        while (bossFound == false)
        {
            // Place rooms

            bool validLayout = false;

            while (!validLayout)
                {
                    validLayout = true;
                    RandomizeLayout();

                    for (int i = 0; i < 15; i++)
                    {
                        FindValidRooms();

                        bool success = PlaceRooms();
                        if (!success)
                            validLayout = false;
                    }
                }

            // Check for boss room
            for (int i = 0; i < 100; i++)
            {
                FindValidRooms();

                int range = availableRooms.Length;
                int randRoom = Random.Range(0, range);
                ArraySize = range;

                if (!bossFound)
                {
                    Vector2 index = availableRooms[randRoom];

                    if (roomLayout[(int)index.x, (int)index.y].down == 1)
                    {
                        int numDoors = 0;
                        if (roomLayout[(int)index.x, (int)index.y].up == 1)
                            numDoors++;

                        if (roomLayout[(int)index.x, (int)index.y].right == 1)
                            numDoors++;

                        if (roomLayout[(int)index.x, (int)index.y].left == 1)
                            numDoors++;

                        if (numDoors == 0)
                        {
                            bossCoords = index;
                            roomLayout[(int)index.x, (int)index.y].left = 2;
                            roomLayout[(int)index.x, (int)index.y].up = 2;
                            roomLayout[(int)index.x, (int)index.y].right = 2;
                            roomLayout[(int)index.x, (int)index.y].down = 1;
                            roomLayout[(int)index.x, (int)index.y].roomState = 2;
                            bossFound = true;
                        }
                    }
                }
            }
            
        }

        return true;
    }

    bool PlaceRooms()
    {
        int size = availableRooms.Length;
        int index = Random.Range(0, size);

        Vector2 temp = availableRooms[index];
        int x = (int)temp.x;
        int y = (int)temp.y;

        PreRoom theRoom = roomLayout[x, y];

        // Check for type of room
        int numDoors = 0;
        int numWalls = 0;

        if (theRoom.up == 1)
            numDoors++;
        else if (theRoom.up == 2)
            numWalls++;

        if (theRoom.right == 1)
            numDoors++;
        else if (theRoom.right == 2)
            numWalls++;

        if (theRoom.down == 1)
            numDoors++;
        else if (theRoom.down == 2)
            numWalls++;

        if (theRoom.left == 1)
            numDoors++;
        else if (theRoom.left == 2)
            numWalls++;

        // Check what type of room it is
        // 1 entrance and 0 walls
        if (numDoors == 1 && numWalls == 0)
            theRoom = OneDoorThreeVacant(theRoom);

        // 1 entrance and 1 wall
        if (numDoors == 1 && numWalls == 1)
            theRoom = OneDoorOneWall(theRoom);

        // 1 entrance and 2 walls
        if (numDoors == 1 && numWalls == 2)
            theRoom = OneDoorTwoWalls(theRoom);

        // 1 entrance and 3 walls
        if (numDoors == 1 && numWalls == 3)
            theRoom = OneDoorThreeWalls(theRoom);

        // 2 entrances and X walls
        if (numDoors == 2)
            theRoom = TwoDoors(theRoom);

        // 3 entrances and X walls
        if (numDoors == 3)
            theRoom = ThreeDoors(theRoom);

        // 4 entrances
        if (numDoors == 4)
        {

        }

        roomLayout[x, y] = theRoom;

        return true;
    }

    PreRoom OneDoorThreeVacant(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;
        int vacant = Random.Range(0, 3);
        Vector2 otherPos;

        bool setTop = true;
        bool setRight = true;
        bool setDown = true;
        bool setLeft = true;

        bool up = false;
        bool right = false;
        bool down = false;
        bool left = false;

        if (theRoom.up == 1)
            up = true;

        if (theRoom.right == 1)
            right = true;

        if (theRoom.down == 1)
            down = true;

        if (theRoom.left == 1)
            left = true;

        if (up)
        {
            setTop = false;
            if (vacant == 0)
            {
                theRoom.right = 2;
                theRoom.down = 1;
                theRoom.left = 1;
            }
            else if (vacant == 1)
            {
                theRoom.right = 1;
                theRoom.down = 2;
                theRoom.left = 1;
            }
            else if (vacant == 2)
            {
                theRoom.right = 1;
                theRoom.down = 1;
                theRoom.left = 2;
            }
        }

        if (right)
        {
            setRight = false;
            if (vacant == 0)
            {
                theRoom.up = 2;
                theRoom.down = 1;
                theRoom.left = 1;
            }
            else if (vacant == 1)
            {
                theRoom.up = 1;
                theRoom.down = 2;
                theRoom.left = 1;
            }
            else if (vacant == 2)
            {
                theRoom.up = 1;
                theRoom.down = 1;
                theRoom.left = 2;
            }
        }

        if (down)
        {
            setDown = false;
            if (vacant == 0)
            {
                theRoom.up = 2;
                theRoom.right = 1;
                theRoom.left = 1;
            }
            else if (vacant == 1)
            {
                theRoom.up = 1;
                theRoom.right = 2;
                theRoom.left = 1;
            }
            else if (vacant == 2)
            {
                theRoom.up = 1;
                theRoom.right = 1;
                theRoom.left = 2;
            }
        }

        if (left)
        {
            setLeft = false;
            if (vacant == 0)
            {
                theRoom.up = 2;
                theRoom.right = 1;
                theRoom.down = 1;
            }
            else if (vacant == 1)
            {
                theRoom.up = 1;
                theRoom.right = 2;
                theRoom.down = 1;
            }
            else if (vacant == 2)
            {
                theRoom.up = 1;
                theRoom.right = 1;
                theRoom.down = 2;
            }
        }

        if (setTop)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y += 1;
            if (theRoom.up == 1)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].down = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }
            else if (theRoom.up == 2)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].down = 2;
            }

            theRoom.roomState = 2;
        }

        if (setRight)
        {
            // Set room to the right
            otherPos = theRoom.pos;
            otherPos.x += 1;
            if (theRoom.right == 1)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }
            else if (theRoom.right == 2)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 2;
            }

            theRoom.roomState = 2;
        }

        if (setDown)
        {
            // Set room to the bottom
            otherPos = theRoom.pos;
            otherPos.y -= 1;
            if (theRoom.down == 1)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].up = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }
            else if (theRoom.down == 2)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].up = 2;
            }

            theRoom.roomState = 2;
        }

        if (setLeft)
        {
            // Set room to the left
            otherPos = theRoom.pos;
            otherPos.x -= 1;
            if (theRoom.left == 1)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }
            else if (theRoom.down == 2)
            {
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 2;
            }

            theRoom.roomState = 2;
        }
        
        return theRoom;

    }

    PreRoom OneDoorOneWall(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;
        Vector2 otherPos;

        bool setTop = true;
        bool setRight = true;
        bool setDown = true;
        bool setLeft = true;

        if (theRoom.up != 0)
            setTop = false;

        if (theRoom.right != 0)
            setRight = false;

        if (theRoom.down != 0)
            setDown = false;

        if (theRoom.left != 0)
            setLeft = false;

        bool randCheck = true;
        int randVal = 0;

        if (setTop)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y += 1;

            // See if we place a door or a wall
            if (randCheck)
                randVal = Random.Range(0, 2);

            if (randVal == 0)
                randCheck = false;

            if (randCheck)
            {
                theRoom.up = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].down = 2;
            }
            else
            {
                theRoom.up = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].down = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }

            randCheck = true;

        }

        if (setRight)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.x += 1;

            // See if we place a door or a wall
            if (randCheck)
                randVal = Random.Range(0, 2);

            if (randVal == 0)
                randCheck = false;

            if (randCheck)
            {
                theRoom.right = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 2;
            }
            else
            {
                theRoom.right = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }

            randCheck = true;

        }

        if (setDown)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y -= 1;

            // See if we place a door or a wall
            if (randCheck)
                randVal = Random.Range(0, 2);

            if (randVal == 0)
                randCheck = false;

            if (randCheck)
            {
                theRoom.down = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].up = 2;
            }
            else
            {
                theRoom.down = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].up = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }

            randCheck = true;

        }

        if (setLeft)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.x -= 1;

            // See if we place a door or a wall
            if (randCheck)
                randVal = Random.Range(0, 2);

            if (randVal == 0)
                randCheck = false;

            if (randCheck)
            {
                theRoom.left = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].right = 2;
            }
            else
            {
                theRoom.left = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].right = 1;
                roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
            }

            randCheck = true;

        }

        theRoom.roomState = 2;

        return theRoom;

    }

    PreRoom OneDoorTwoWalls(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;
        Vector2 otherPos;

        bool setTop = true;
        bool setRight = true;
        bool setDown = true;
        bool setLeft = true;

        if (theRoom.up != 0)
            setTop = false;

        if (theRoom.right != 0)
            setRight = false;

        if (theRoom.down != 0)
            setDown = false;

        if (theRoom.left != 0)
            setLeft = false;

        if (setTop)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y += 1;

            theRoom.up = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].down = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
        }

        if (setRight)
        {
            // Set room to the right
            otherPos = theRoom.pos;
            otherPos.x += 1;

            theRoom.right = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].left = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
        }

        if (setDown)
        {
            // Set room to the bottom
            otherPos = theRoom.pos;
            otherPos.y -= 1;

            theRoom.down = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].up = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
        }

        if (setLeft)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.x -= 1;

            theRoom.left = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].right = 1;
            roomLayout[(int)otherPos.x, (int)otherPos.y].roomState = 1;
        }

        theRoom.roomState = 2;

        return theRoom;

    }

    PreRoom OneDoorThreeWalls(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;

        // We done bruh
        theRoom.roomState = 2;

        return theRoom;

    }

    PreRoom TwoDoors(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;
        Vector2 otherPos;

        bool setTop = true;
        bool setRight = true;
        bool setDown = true;
        bool setLeft = true;

        if (theRoom.up == 0)
            setTop = false;

        if (theRoom.right == 0)
            setRight = false;

        if (theRoom.down == 0)
            setDown = false;

        if (theRoom.left == 0)
            setLeft = false;

        if (setTop)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y += 1;

            theRoom.up = 2;
            roomLayout[(int)otherPos.x, (int)otherPos.y].down = 2;
        }

        if (setRight)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.x += 1;

            theRoom.right = 2;
            roomLayout[(int)otherPos.x, (int)otherPos.y].left = 2;
        }

        if (setDown)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.y -= 1;

            theRoom.down = 2;
            roomLayout[(int)otherPos.x, (int)otherPos.y].up = 2;
        }

        if (setLeft)
        {
            // Set room to the top
            otherPos = theRoom.pos;
            otherPos.x -= 1;

            theRoom.left = 2;
            roomLayout[(int)otherPos.x, (int)otherPos.y].right = 2;
        }

        theRoom.roomState = 2;

        return _theRoom;
    }

    PreRoom ThreeDoors(PreRoom _theRoom)
    {
        PreRoom theRoom = _theRoom;
        Vector2 otherPos;

        bool setTop = true;
        bool setRight = true;
        bool setDown = true;
        bool setLeft = true;

        if (theRoom.up == 1)
            setTop = false;

        if (theRoom.right == 1)
            setRight = false;

        if (theRoom.down == 1)
            setDown = false;

        if (theRoom.left == 1)
            setLeft = false;

        if (setTop)
        {
            if (theRoom.up != 2)
            {
                // Set room to the top
                otherPos = theRoom.pos;
                otherPos.y += 1;

                theRoom.up = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].down = 2;
            }
        }

        if (setRight)
        {
            if (theRoom.right != 2)
            {
                // Set room to the top
                otherPos = theRoom.pos;
                otherPos.x += 1;

                theRoom.right = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].left = 2;
            }
        }

        if (setDown)
        {
            if (theRoom.down != 2)
            {
                // Set room to the top
                otherPos = theRoom.pos;
                otherPos.y -= 1;

                theRoom.down = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].up = 2;
            }
        }

        if (setLeft)
        {
            if (theRoom.left != 2)
            {
                // Set room to the top
                otherPos = theRoom.pos;
                otherPos.x -= 1;

                theRoom.left = 2;
                roomLayout[(int)otherPos.x, (int)otherPos.y].right = 2;
            }
        }

        theRoom.roomState = 2;

        return _theRoom;
    }

    void ForceValidation()
    {

        roomLayout[4, 5].down = 1;
        roomLayout[5, 4].left = 1;
        roomLayout[4, 3].up = 1;
        roomLayout[3, 4].right = 1;

        roomLayout[1, 1].left = 2;
        roomLayout[1, 2].left = 2;
        roomLayout[1, 3].left = 2;
        roomLayout[1, 4].left = 2;
        roomLayout[1, 5].left = 2;
        roomLayout[1, 6].left = 2;
        roomLayout[1, 7].left = 2;

        roomLayout[7, 1].right = 2;
        roomLayout[7, 2].right = 2;
        roomLayout[7, 3].right = 2;
        roomLayout[7, 4].right = 2;
        roomLayout[7, 5].right = 2;
        roomLayout[7, 6].right = 2;
        roomLayout[7, 7].right = 2;

        roomLayout[1, 1].up = 2;
        roomLayout[2, 1].up = 2;
        roomLayout[3, 1].up = 2;
        roomLayout[4, 1].up = 2;
        roomLayout[5, 1].up = 2;
        roomLayout[6, 1].up = 2;
        roomLayout[7, 1].up = 2;

        roomLayout[1, 7].down = 2;
        roomLayout[2, 7].down = 2;
        roomLayout[3, 7].down = 2;
        roomLayout[4, 7].down = 2;
        roomLayout[5, 7].down = 2;
        roomLayout[6, 7].down = 2;
        roomLayout[7, 7].down = 2;


        for (int i = 1; i < 8; i++)
        {
            for(int j = 1; j < 8; j++)
            {
                PreRoom theRoom = roomLayout[i, j];

                if(theRoom.up == 1)
                {
                    int y = j + 1;
                    roomLayout[i, y].down = 1;
                }

                if (theRoom.right == 1)
                {
                    int x = i + 1;
                    roomLayout[x, j].left = 1;
                }

                if (theRoom.down == 1)
                {
                    int y = j - 1;
                    roomLayout[i, y].up = 1;
                }

                if (theRoom.left == 1)
                {
                    int x = i - 1;
                    roomLayout[x, j].right = 1;
                }
            }
        }

        Vector2 dungeonPos = bossCoords;
        dungeonPos.y -= 1;

        bool dungY = false;
        bool dungX = false;

        while(dungX == false)
        {
            if (dungeonPos.x != 4)
            {
                if(dungeonPos.x < 4)
                {
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].right = 1;
                    dungeonPos.x += 1;
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].left = 1;
                }

                if (dungeonPos.x > 4)
                {
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].left = 1;
                    dungeonPos.x -= 1;
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].right = 1;
                }
            }
            else
                dungX = true;
        }

        while (dungY == false)
        {
            if (dungeonPos.y != 4)
            {
                if (dungeonPos.y < 4)
                {
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].up = 1;
                    dungeonPos.y += 1;
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].down = 1;
                }

                if (dungeonPos.y > 4)
                {
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].down = 1;
                    dungeonPos.y -= 1;
                    roomLayout[(int)dungeonPos.x, (int)dungeonPos.y].up = 1;
                }
            }
            else
                dungY = true;
        }

    }

    void EmbedMatrix()
    {
        // Set every room style
        for(int i = 1; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                PreRoom theRoom = roomLayout[i, j];
                int type = 0;
                type = Random.Range(0, 2);

                theRoom.style = 0;

                // Empty room
                if (theRoom.up !=1 && theRoom.right != 1 && theRoom.down != 1 && theRoom.left != 1)
                    theRoom.style = 0;

                // Treasure or Armory room with a door at the top
                if (theRoom.up == 1 && theRoom.right != 1 && theRoom.down != 1 && theRoom.left != 1)
                {
                    if(type == 0)
                        theRoom.style = 7;
                    else
                        theRoom.style = 11;
                }
                    

                // Treasure or Armory room with a door at the right
                if (theRoom.up != 1 && theRoom.right == 1 && theRoom.down != 1 && theRoom.left != 1)
                {
                    if (type == 0)
                        theRoom.style = 8;
                    else
                        theRoom.style = 12;
                }

                // Treasure or Armory room with a door at the bottom
                if (theRoom.up != 1 && theRoom.right != 1 && theRoom.down == 1 && theRoom.left != 1)
                {
                    if (type == 0)
                        theRoom.style = 9;
                    else
                        theRoom.style = 13;
                }

                // Treasure or Armory room with a door at the left
                if (theRoom.up != 1 && theRoom.right != 1 & theRoom.down != 1 && theRoom.left == 1)
                {
                    if (type == 0)
                        theRoom.style = 10;
                    else
                        theRoom.style = 14;
                }

                // Combat room with a door at the top and the right
                if (theRoom.up == 1 && theRoom.right == 1 && theRoom.down != 1 && theRoom.left != 1)
                    theRoom.style = 1;

                // Combat room with a door at the top and the bottom
                if (theRoom.up == 1 && theRoom.right != 1 && theRoom.down == 1 && theRoom.left != 1)
                    theRoom.style = 2;

                // Combat room with a door at the top and the left
                if (theRoom.up == 1 && theRoom.right != 1 && theRoom.down != 1 && theRoom.left == 1)
                    theRoom.style = 3;

                // Combat room with a door at the right and the bottom
                if (theRoom.up != 1 && theRoom.right == 1 && theRoom.down == 1 && theRoom.left != 1)
                    theRoom.style = 4;

                // Combat room with a door at the right and the left
                if (theRoom.up != 1 && theRoom.right == 1 && theRoom.down != 1 && theRoom.left == 1)
                    theRoom.style = 5;

                // Combat room with a door at the bottom and the left
                if (theRoom.up != 1 && theRoom.right != 1 && theRoom.down == 1 && theRoom.left == 1)
                    theRoom.style = 6;

                // Combat room with a door at the top right and bottom
                if (theRoom.up == 1 && theRoom.right == 1 && theRoom.down == 1 && theRoom.left != 1)
                    theRoom.style = 18;

                // Combat room with a door at the right bottom and left
                if (theRoom.up != 1 && theRoom.right == 1 && theRoom.down == 1 && theRoom.left == 1)
                    theRoom.style = 15;

                // Combat room with a door at the bottom left and top
                if (theRoom.up == 1 && theRoom.right != 1 && theRoom.down == 1 && theRoom.left == 1)
                    theRoom.style = 16;

                // Combat room with a door at the left top and right
                if (theRoom.up == 1 && theRoom.right == 1 && theRoom.down != 1 && theRoom.left == 1)
                    theRoom.style = 17;

                // Combat room with a door at the left top and right
                if (theRoom.up == 1 && theRoom.right == 1 && theRoom.down == 1 && theRoom.left == 1)
                    theRoom.style = 21;

                roomLayout[i, j] = theRoom;
            }
        }

        roomLayout[4, 4].style = 19;
        roomLayout[(int)bossCoords.x, (int)bossCoords.y].style = 20;

        // Fill in the rooms

        for(int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row1[i] = roomLayout[refNum, 1].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row2[i] = roomLayout[refNum, 2].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row3[i] = roomLayout[refNum, 3].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row4[i] = roomLayout[refNum, 4].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row5[i] = roomLayout[refNum, 5].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row6[i] = roomLayout[refNum, 6].style;
        }

        for (int i = 0; i < 7; i++)
        {
            int refNum = i + 1;
            Row7[i] = roomLayout[refNum, 7].style;
        }


    }

    // STEPS:
    // Set rooms to default
    // Set start room and adjacent rooms
    // Check for valid rooms
    // If room has 1 entrance and 3 undecided sides
    // Place 2 entrances randomly on all valid rooms and mark one wall
    // For each of those entrances, mark an open door in the next room. Mark the room as valid
    // Mark a wall in every room adjacent to a wall
    // If room has 1 entrance and 1 wall
    // 50% chance to mark both other walls as doors, 50% chance to mark one as a door and the other as a wall
    // If room has 2 entrances, place walls on every other side and mark the room as complete
    // Mark a wall in every room adjacent to a wall
    // If room has 3 entrances, place a wall on the last side and mark the room as complete
    // Mark a wall in the adjacent room
    // If room has 4 entrances, fuck. Just restart the whole process. Thats some grade A fuckery right there.
    // Check for invalid rooms
    // Check through every room. If the room has 2 walls or more, mark all the sides as walls
    // Mark all of the adjacent room's walls as well
    // After placing X number of rooms, find a location for the boss room.
    // Check for valid rooms
    // Check a random valid room. If the room has an available room above it, place the boss room there.
    // If, after checking every room randomly, no valid boss room is found, restart the entire room building process.

    //*===*

    // After placing the boss, iterate through the non-finalized valid rooms and clean up the level.

    // If a room has 1 entrance and 3 undecided sides, delete that shit. We done with world building

    // If a room has 3 doors, but only one of those doors is connected to another valid or finished room
    // Mark the room as empty and set all sides to open. We dont want snaking rooms everywhere

    // If a room has 3 doors, and 2 of them are connected to valid or finished rooms
    // Mark the room as complete and mark the room at the other side of the 3rd door as complete as well.
    // Mark the door in the other room. This will become a treasure / armory room.

    // If a room has 2 doors, mark the room as complete and block off the other walls etc


    // Iterate through all of the rooms in the matrix. Based on the door / wall position, flag each room style as the appropriate number

    // Place all of the style data into the actual room arrays.
    // Pray



}
