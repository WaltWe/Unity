using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void Start()
    {
            Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (!other.tag.Equals("Destroyer") && !other.tag.Equals("powerUp"))
        {
            Destroy(other.gameObject);
        }
	}
}
