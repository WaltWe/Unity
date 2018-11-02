using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        /*if (Input.GetAxis("Horizontal") * 0.25f == 0)
        {

        }
        if ((Mathf.Abs(transform.position.x - player.transform.position.x)) >= 0.5)
        {
            transform.Translate(Input.GetAxis("Horizontal") * 0.25f, 0, 0);
        }*/
	}
}