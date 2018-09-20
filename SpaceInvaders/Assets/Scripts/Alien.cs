using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public Sprite[] sprites;
    public int Row = 0;
    public int Col = 0;
    public int level = 1;

    // Use this for initialization
    void Start () {
		if(Col == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[8];
        }
        if(Col == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
        if (Col == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        if (Col == 4)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        if(Col == 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
