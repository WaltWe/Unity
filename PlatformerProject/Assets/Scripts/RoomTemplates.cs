using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public int unfinishedCheck = 0;
    public int numRooms = 0;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    
    public GameObject[] bosses;
    public GameObject[] powerups;

    private GameObject[] bossRooms = new GameObject[3];
    private GameObject[] powerRooms = new GameObject[3];

    private void Start()
    {
        Invoke("makeBoss", 15f);
        Invoke("makePower", 16f);
        Invoke("makeTerrain", 17f);
    }

    private void Update()
    {

    }

    public void makeBoss()
    {
        int boss1 = rooms.Count - Random.Range(rooms.Count / 7, 2 * rooms.Count / 7 - 1);
        int boss2 = rooms.Count - Random.Range(2 * rooms.Count / 7 + 1, 3 * rooms.Count / 7 - 1);
        int boss3 = rooms.Count - Random.Range(3 * rooms.Count / 7 + 1, 4 * rooms.Count / 7 - 1);
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == boss1)
            {
                Instantiate(bosses[0], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                //Debug.Log("Make boss 1");
                bossRooms[0] = rooms[i];
            }
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == boss2)
            {
                Instantiate(bosses[1], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                //Debug.Log("Make boss 2");
                bossRooms[1] = rooms[i];
            }
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == boss3)
            {
                Instantiate(bosses[2], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                //Debug.Log("Make boss 3");
                bossRooms[2] = rooms[i];
            }
        }
    }
    
    public void makePower()
    {
        int power1 = Random.Range(1 * rooms.Count / 7 + 1, 2 * rooms.Count / 7 - 1);
        int power2 = Random.Range(2 * rooms.Count / 7 + 1, 3 * rooms.Count / 7 - 1);
        int power3 = Random.Range(3 * rooms.Count / 7 + 1, 4 * rooms.Count / 7 - 1);
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == power1)
            {
                Instantiate(powerups[0], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                powerRooms[0] = rooms[i];
            }
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == power2)
            {
                Instantiate(powerups[1], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                powerRooms[1] = rooms[i];
            }
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == power3)
            {
                Instantiate(powerups[2], new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, rooms[i].transform.position.z + 10), Quaternion.identity);
                powerRooms[2] = rooms[i];
            }
        }
    }
}
