using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public Vector3 velocity = new Vector3(750, 0, 0);

	// Use this for initialization
	void Start () {
        playerdata.numEnemies++;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = velocity;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Substring(0, 4).Equals("Wall"))
        {
            velocity = new Vector3(-velocity.x, 0, 0);
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
            playerdata.numEnemies--;
        }
    }
}
