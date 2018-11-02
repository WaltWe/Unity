using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(Camera.main.transform);
        transform.RotateAround(Vector3.zero, Vector3.back, 20 * Time.deltaTime);
	}
}
