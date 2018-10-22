using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public Sprite[] sprites;
    public int Row = 0;
    public int Col = 0;
    public int maxRow = 0;
    public int maxCol = 0;
    public int level = 1;
    public static int cooldown = 0;
    public AudioClip deathSound;
    private AudioSource source;
    public int hitcount;
    public GameObject bullet;
    public bool hasPowerup = false;
    public GameObject powerup;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        if(Stats.level <= 11)
        {
            cooldown = Random.Range(10, 600);
        }
        else
        {
            cooldown = 10;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[getSprite()];
        hitcount = getSprite();
        if (getSprite() == 0)
        {
            GetComponent<Animator>().SetBool("Green", true);
        }
        else if(getSprite() == 1)
        {
            GetComponent<Animator>().SetBool("Orange", true);

        }
        else if(getSprite() == 2)
        {
            GetComponent<Animator>().SetBool("Red", true);
        }
        else if(getSprite() == 3)
        {
            GetComponent<Animator>().SetBool("Blue", true);
        }else if(getSprite() == 8)
        {
            GetComponent<Animator>().SetBool("Boss", true);
        }
        if (Random.Range(1, 50 / (getSprite() + 1)) == 1)
        {
            hasPowerup = true;
        }
    }
	
    int getSprite()
    {
        if(level > 11)
        {
            return 8;
        }
        int sprite = (-Col+level)/2;
        if(sprite < 0) { sprite = 0; }
        if(sprite > 3) { sprite = 3; }
        return sprite;
    }

	// Update is called once per frame
	void Update () {
        if (cooldown <= 0 && !Stats.pause && Stats.level<=11)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreLayerCollision(8, 9);
            cooldown = Random.Range(60, 2000);
        }
        else if((Mathf.Abs(GameObject.Find("Spaceship").transform.position.x)-Mathf.Abs(transform.position.x))<.1 && cooldown <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreLayerCollision(8, 9);
            cooldown = 5;
        }
        cooldown--;
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            if(hitcount <= 0)
            {
                Stats.score++;
                GameObject.Find("LevelManager").GetComponent<LevelManager>().alienCount--;
                Destroy(GetComponent<Collider2D>());
                StartCoroutine(death());
            }
            Destroy(collision.gameObject);
            hitcount--;
        }
    }
    public IEnumerator death()
    {
        Animator animate = GetComponent<Animator>();
        animate.SetBool("Death", true);
        source.PlayOneShot(deathSound, .75f);
        yield return new WaitForSeconds(1f);
        if (hasPowerup)
        {
            GameObject pup = Instantiate(powerup,transform.position,Quaternion.identity);
            pup.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            GameObject.Find("Shields").GetComponent<Shields>().ignoreCollision(pup);
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Bullet").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Aliens").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        Destroy(gameObject);
    }
}