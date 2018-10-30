using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(-Camera.main.pixelWidth/2, 0, 0)).x)
        {
            Destroy(gameObject);
        }
	}
}
