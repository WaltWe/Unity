using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovementBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x/-1) < mouseX && mouseX < (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x)/1)
        {
            //transform.position = new Vector2(mouseX,-4);
            transform.position = new Vector2(GameObject.Find("Ball").transform.position.x,-4);
        }
	}
}
