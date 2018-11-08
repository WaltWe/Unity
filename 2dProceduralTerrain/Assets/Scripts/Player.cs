using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool onGround = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 2f, 0, 0);
        if (Input.GetKeyDown("space") && onGround)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, 50);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground(Clone)")
        {
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground(Clone)")
        {
            onGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground(Clone)")
        {
            onGround = true;
        }
    }
}
