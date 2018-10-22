using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public AudioClip shootSound;
    private AudioSource source;

    // Use this for initialization

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start () {
        source.PlayOneShot(shootSound, .4f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        Physics2D.IgnoreCollision(GameObject.Find("Spaceship").GetComponent<Spaceship>().shield.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,0)).y)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ShieldBlock")
        {
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
