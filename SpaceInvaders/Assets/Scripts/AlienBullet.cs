using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {

    public AudioClip shootSound;
    private AudioSource source;

    // Use this for initialization

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.PlayOneShot(shootSound, .2f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y)
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
        if(collision.gameObject.name == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
