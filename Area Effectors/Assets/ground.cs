using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {

    public GameObject force;
    public bool hasForce = false;

	// Use this for initialization
	void Start () {
        if (Random.Range(0, 10) == 0)
        {
            hasForce = true;
        }
        if (hasForce)
        {
            GameObject newForce = Instantiate(force, new Vector2(transform.position.x, transform.position.y + 4), Quaternion.identity);
            newForce.transform.eulerAngles = new Vector3(0, 0, 90);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(-Camera.main.pixelWidth/2, 0, 0)).x)
        {
            Destroy(gameObject);
        }
	}
}
