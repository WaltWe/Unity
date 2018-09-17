using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Brick").Length; i++)
        {
            Physics.IgnoreCollision(bricks[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
        Physics.IgnoreCollision(GameObject.Find("Brick(Clone)").GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("Ball").GetComponent<Collider>(), GetComponent<Collider>());
        GetComponent<Rigidbody>().velocity = new Vector3(0, -4f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y< (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y * -1))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        GameObject colObj = col.gameObject;
        if (colObj.name == "Paddle")
        {
            PowerUps.clearAll();
            PowerUps.force++;
            GameObject.Find("Ball").GetComponent<SpriteRenderer>().color = new Color(255f/255f,86f/255f,0f/255f,255f/255f);
            GameObject.Find("Ball").GetComponent<TrailRenderer>().startColor = new Color(255f / 255f, 86f / 255f, 0f / 255f, 255f / 255f);
            GameObject.Find("Paddle").GetComponent<PaddleMovementBehaviour>().powerCount = 600;
            Destroy(gameObject);
        }
    }
}
