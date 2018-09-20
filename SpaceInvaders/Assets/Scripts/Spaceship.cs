using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float speed = 0.25f;
    public int cooldown = 0;

    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);
        if (Input.GetKeyDown("space") && cooldown <= 0)
        {
            shoot();
        }
        cooldown--;
	}

    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
