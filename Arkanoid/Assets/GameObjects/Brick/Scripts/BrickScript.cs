using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
    int id;
    public int hitCount;
    private SpriteRenderer spr;
    public Sprite[] sprites;

    // Use this for initialization
    void Start () {
        Physics.IgnoreCollision(GameObject.Find("Paddle").GetComponent<Collider>(), GetComponent<Collider>());
        id = Random.Range(Mathf.CeilToInt((Time.time) / 30), Mathf.CeilToInt((Time.time + 15) / 30)+1);
        id--;
        if (id < 0) { id = 0; }
        hitCount = id+1;
        if (id > 4) { id = 4; }
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[id];
        GetComponent<Rigidbody>().velocity = new Vector3(0, -.1f, 0);
        if (Mathf.Abs(Camera.main.aspect - (9f / 16f)) < .001) { GetComponent<Transform>().localScale = new Vector3(Mathf.RoundToInt(GetComponent<Transform>().localScale.x * ((Camera.main.pixelWidth / 16.0f) / 32.0f)), GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z); }
        Debug.Log(GetComponent<SpriteRenderer>().size.x);
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
        }
        int sprID = hitCount - 1;
        if(sprID > 4)
        {
            sprID = 4;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[sprID];
    }

    
}
