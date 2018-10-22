using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float speed = 0.25f;
    public int cooldown = 0;
    public AudioClip deathSound;
    private AudioSource source;
    public int powerCount = 0;
    public bool powered = false;
    public GameObject bullet;
    public GameObject shield;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x >= -Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x && transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x && !Stats.pause)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);
        }
        if(transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - Camera.main.ScreenToWorldPoint(new Vector3(GetComponent<Renderer>().bounds.size.x, 0, 0)).x / 10)
        {
            transform.position = new Vector3(-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - Camera.main.ScreenToWorldPoint(new Vector3(GetComponent<Renderer>().bounds.size.x, 0, 0)).x / 10, transform.position.y, transform.position.z);
        }
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x + Camera.main.ScreenToWorldPoint(new Vector3(GetComponent<Renderer>().bounds.size.x, 0, 0)).x / 10)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x + Camera.main.ScreenToWorldPoint(new Vector3(GetComponent<Renderer>().bounds.size.x, 0, 0)).x / 10, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("space") && cooldown <= 0 && !Stats.pause)
        {
            shoot();
            cooldown = 30;
        }
        cooldown--;
        if (Stats.powerup)
        {
            powered = true;
            powerCount = 300;
        }
        if(powered && powerCount <= 0)
        {
            powered = false;
        }
        if (powered)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
	}

    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Alien Bullet(Clone)")
        {
            Destroy(collision.gameObject);
            Stats.lives--;
            if (Stats.lives == 0)
            {
                StartCoroutine(Death());
            }
        }
        if(collision.gameObject.name == "PowerUp(Clone)")
        {
            Stats.powerup = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Death()
    {
        GetComponent<Animator>().SetBool("Death", true);
        source.PlayOneShot(deathSound, 1f);
        yield return new WaitForSecondsRealtime(1);
        GameObject.Find("LevelManager").GetComponent<LevelManager>().death();
    }
}
