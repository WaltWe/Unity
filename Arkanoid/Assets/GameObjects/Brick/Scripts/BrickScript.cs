using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
    public int id;
    public int hitCount;
    private SpriteRenderer spr;
    public Sprite[] sprites;

    delegate float SpawnEquation(float time);
    delegate float DerivativeIdEqn(float time);

    // Use this for initialization
    void Start () {
        Physics.IgnoreCollision(GameObject.Find("Paddle").GetComponent<Collider>(), GetComponent<Collider>());
        double idVsTime = (((Mathf.Sin((Time.time - 1) + Mathf.PI) / 2) + ((Time.time - 1) / 2)) / (2.5)) / 3;
        SpawnEquation myMathFunc = (time) =>
        {
            return (float)(((Mathf.Sin((time - 1) + Mathf.PI) / 2) + ((time - 1) / 2)) / (2.5)) / 3;
        };
        var derivativeEqn = derive(myMathFunc);
        var derivative = derivativeEqn(Time.time);
        if(0.0001 > derivative && derivative > -0.0001)
        {
            GameObject.Find("BrickGenerator").GetComponent<BrickGenerationBehavior>().count++;
            id = GameObject.Find("BrickGenerator").GetComponent<BrickGenerationBehavior>().count;
        }
        id = (int)Random.Range((float)idVsTime - 1, (float)idVsTime + 1);
        if (id == 0) { id++; }
        if (id > 5) { id = 5; }
        hitCount = id;
        id--;
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[id];
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1f, 0);
        
    }

    DerivativeIdEqn derive(SpawnEquation f, float h = 0.0001f)
    {
        return (x) => (f(x + h) - f(x)) / h;
    }

    // Update is called once per frame
    void Update () {
        //var d = derivativeEqn(Time.time);
        //Debug.Log("Derivative: " + d);
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
