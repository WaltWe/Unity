using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
    int id;
    public int hitCount;
    private SpriteRenderer spr;
    public Sprite[] sprites;
    public GameObject[] powerups;
    public int force;
    public int speed;
    public int explode;
    public bool useSpeed = false;
    public bool useForce = false;
    public bool useExplode = false;
    // Use this for initialization
    void Start () {
        //Physics.IgnoreCollision(GameObject.Find("Paddle").GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("Ceiling").GetComponent<Collider>(), GetComponent<Collider>());
        id = Random.Range(Mathf.CeilToInt((Time.timeSinceLevelLoad) / 30), Mathf.CeilToInt((Time.timeSinceLevelLoad + 15) / 30)+1);
        id--;
        if (id < 0) { id = 0; }
        hitCount = id+1;
        if (id > 4) { id = 4; }
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[id];
        GetComponent<Rigidbody>().velocity = new Vector3(0, -.1f, 0);
        if (Mathf.Abs(Camera.main.aspect - (10f / 16f)) < .001) { GetComponent<Transform>().localScale = new Vector3((GetComponent<Transform>().localScale.x / 2f), GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z); }
        force = Random.Range(3*id + 1, 50);
        if (force == 1)
        {
            useForce = true;
        }
        speed = Random.Range(3 * id + 1, 50);
        if (speed == 1)
        {
            useSpeed = true;
        }
        explode = Random.Range(id * id + 1, 50);
        if(explode == 1)
        {
            useExplode = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x > (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x))
        {
            Destroy(gameObject);
        }
        if (transform.position.y < (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y * -1))
        {
            Destroy(gameObject);
            GameObject.Find("Lives").GetComponent<LivesScript>().lives--;
            GameObject.Find("Mobile Lives").GetComponent<LivesScript>().lives--;
        }
        if(hitCount <= 0)
        {
            Destroy(gameObject);
        }
        int sprID = hitCount - 1;
        if(sprID > 4)
        {
            sprID = 4;
        }
        if(sprID < 0)
        {
            sprID = 0;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[sprID];
    }
}
