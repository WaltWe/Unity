using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeleter : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < player.transform.position.x-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, 0, 0)).x * 32)
        {
            Destroy(gameObject);
        }
	}
}
