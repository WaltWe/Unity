using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGenerator : MonoBehaviour
{

    public GameObject ground;

    public float leftX;
    public float groundWidth;
    public float maxGround;
    public float curX;
    public float X;
    public float curY;
    public float y;
    // Use this for initialization
    void Start()
    {
        y = GetComponentInParent<Transform>().position.x;
        X = GetComponentInParent<Transform>().position.x;
        groundWidth = ground.GetComponent<Renderer>().bounds.size.x;
        leftX = Camera.main.ScreenToWorldPoint(new Vector3(-Camera.main.pixelWidth / 2, 0, 0)).x / 2;
        for (float i = leftX; i < -leftX + groundWidth / 2; i += groundWidth)
        {
            GameObject curGround = Instantiate(ground, new Vector2((i), -1.75f), new Quaternion(0, 0, 0, 0));
            curX = curGround.transform.position.x;
            curY = curGround.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        X = GetComponentInParent<Transform>().position.x;
        if (curX - X <= -2 * leftX)
        {
            GameObject curGround = Instantiate(ground, new Vector2((curX + groundWidth), curY + Random.Range(-100f, 100f) / 250f), new Quaternion(0, 0, 0, 0));
            curX = curGround.transform.position.x;
            curY = curGround.transform.position.y;
        }
    }
}
