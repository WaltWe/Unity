using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovementBehaviour : MonoBehaviour {

    public int powerCount = 0;

	// Use this for initialization
	void Start () {
        if (Mathf.Abs(Camera.main.aspect - (9f / 16f)) < .001) { GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x / 2f, GetComponent<Transform>().localScale.y / 2f, GetComponent<Transform>().localScale.z); }
    }
	
	// Update is called once per frame
	void Update () {
        var mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x/-1) < mouseX && mouseX < (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x)/1)
        {
            //transform.position = new Vector3(mouseX,-4f,1f);
            if (GameObject.Find("Ball").GetComponent<Rigidbody>().velocity.y > 0 && GameObject.Find("BallForce(Clone)") != null)
            {
                transform.position = new Vector3(GameObject.Find("BallForce(Clone)").transform.position.x, -4.5f, 1f);
            }
            else
            {
                transform.position = new Vector3(GameObject.Find("Ball").transform.position.x, -4.5f, 1f);
            }
        }
        powerCount--;
        if (powerCount == 0){
            PowerUps.clearAll();
        }
	}
}
