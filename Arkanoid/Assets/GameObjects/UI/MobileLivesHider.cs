using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLivesHider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Mathf.Abs(Camera.main.aspect - (16f / 9f)) < .001)
        {
            GetComponent<Transform>().position = new Vector3(100f, 100f, 100f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
