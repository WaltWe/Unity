using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geometry : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
        Instantiate(enemy, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
