using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void down()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void up()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void ignoreCollision(GameObject obj)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), transform.GetChild(i).gameObject.GetComponent<Collider2D>());
        }
    }
}
