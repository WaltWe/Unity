using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainGenerator : MonoBehaviour {

    public float X;

	// Use this for initialization
	void Start () {
        X = GetComponentInParent<Transform>().position.x;
	}
	
	// Update is called once per frame
	void Update () {
        X = GetComponentInParent<Transform>().position.x;


    }
}
