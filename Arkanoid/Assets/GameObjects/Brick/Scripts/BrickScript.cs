using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
    public int id;
    public int hitCount;
    private SpriteRenderer spr;
    public Sprite[] sprites;

    public AnimationCurve idCurve;

    delegate float SpawnEquation(float time);
    delegate float DerivativeIdEqn(float time);

    // Use this for initialization
    void Start () {
        Physics.IgnoreCollision(GameObject.Find("Paddle").GetComponent<Collider>(), GetComponent<Collider>());
        id = (int)(((Mathf.Sin((((Time.time)) - 1) + Mathf.PI) / 2) + ((((Time.time)) - 1) / 2)) / (2.5)) / 3;
        id = Random.Range(id-1, id + 1);
        if (id < 0) { id = 0; }
        hitCount = id + 1;
        if (id > 4) { id = 4; }
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[id];
        GetComponent<Rigidbody>().velocity = new Vector3(0, -.1f, 0);
    }

    DerivativeIdEqn derive(SpawnEquation f, float h = 0.000000001f)
    {
        return (x) => (f(x + h) - f(x)) / h;
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
    }

    
}
