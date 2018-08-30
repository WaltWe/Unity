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
        rb.velocity = new Vector3(7*direction, -7, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1)){
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(1, 0, 0)));
            transform.position = new Vector3(-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x, transform.position.y, 1);
        }
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x)){
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(-1, 0, 0)));
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x, transform.position.y, 1);
        }
        if (transform.position.y < (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y * -1)){
            GameObject.Find("Lives").GetComponent<LivesScript>().lives--;
            GameObject.Find("Mobile Lives").GetComponent<LivesScript>().lives--;
            transform.position = new Vector3(0, 0, 1);
        }
        if (transform.position.y > (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y))
        {
            rb.velocity = Vector3.Reflect(oldVel, (new Vector3(0,-1,0)));
            transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y, 1);
        }
        oldVel = rb.velocity;
    }
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Brick(Clone)")
        {
            col.gameObject.GetComponent<BrickScript>().hitCount-=PowerUps.force;
            if(col.gameObject.GetComponent<BrickScript>().hitCount <= 0)
            {
                if (col.gameObject.GetComponent<BrickScript>().useForce)
                {
                    Instantiate(col.gameObject.GetComponent<BrickScript>().powerups[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                }
                Destroy(col.gameObject);
                GameObject.Find("Score").GetComponent<UIScript>().score++;
                GameObject.Find("Mobile Score").GetComponent<UIScript>().score++;
            }
        }
        ContactPoint cp = col.contacts[0];
        rb.velocity = Vector3.Reflect(oldVel, cp.normal);
        rb.velocity += cp.normal * 0.05f;
    }
}
