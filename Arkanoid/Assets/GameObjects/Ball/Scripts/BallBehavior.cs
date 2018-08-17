using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {
    public Rigidbody rb;
    Vector3 oldVel = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        int direction = Random.Range(1,3);
        if (direction == 1)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        rb.velocity = new Vector3(15*direction, -15, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1)){
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(1, 0, 0)));
            transform.position = new Vector3(-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x, transform.position.y, 0);
        }
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x)){
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(-1, 0, 0)));
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x, transform.position.y, 0);
        }
        if (transform.position.y < (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y * -1)){
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(0, 1, 0)));
            transform.position = new Vector3(transform.position.x, -Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y, 0);
        }
        if (transform.position.y > (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y))
        {
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(0,-1,0)));
            transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y, 0);
        }
        oldVel = rb.velocity;
    }
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Brick(Clone)")
        {
            col.gameObject.GetComponent<BrickScript>().hitCount--;
            if(col.gameObject.GetComponent<BrickScript>().hitCount == 0)
            {
                Destroy(col.gameObject);
            }
        }
        ContactPoint cp = col.contacts[0];
        rb.velocity = Vector3.Reflect(oldVel, cp.normal);
        rb.velocity += cp.normal * 0.05f;
    }
}
