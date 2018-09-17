using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplode : MonoBehaviour {

    void Start()
    {
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
    void Update()
    {
        if (transform.position.y < (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y * -1))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        GameObject colObj = col.gameObject;
        if (colObj.name == "Paddle")
        {
            //PowerUps.clearAll();
            PowerUps.explode();
            Destroy(gameObject);
        }
    }
}
