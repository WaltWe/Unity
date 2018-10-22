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
    public float seed;
    public GameObject[] active;
    // Use this for initialization
    void Start()
    {
        seed = Random.Range(100f, 100f);
        y = GetComponentInParent<Transform>().position.x;
        X = GetComponentInParent<Transform>().position.x;
        groundWidth = ground.GetComponent<Renderer>().bounds.size.x;
        leftX = Camera.main.ScreenToWorldPoint(new Vector3(-Camera.main.pixelWidth / 2, 0, 0)).x / 2;
        active = new GameObject[(int)(-leftX * 4 / groundWidth)];

        for (int i = 0; i < active.Length; i++)
        {
            GameObject curGround = Instantiate(ground, new Vector2((leftX * 2)+(groundWidth * i), Mathf.PerlinNoise(seed,y)*10), new Quaternion(0, 0, 0, 0));
            active[i] = curGround;
            curX = curGround.transform.position.x;
        }
        curY = -leftX * 2;
        /*for (float i = leftX; i < -leftX + groundWidth/2; i += groundWidth)
        {
            GameObject curGround = Instantiate(ground, new Vector2((i), -1.75f), new Quaternion(0, 0, 0, 0));
            
            curX = curGround.transform.position.x;
            curY = curGround.transform.position.y;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        X = GetComponentInParent<Transform>().position.x;
        if (curX - X <= -2 * leftX)
        {
            Destroy(active[0]);
            for (int i = 0; i < active.Length - 2; i++)
            {
                active[i] = active[i + 1];
            }
            GameObject curGround = Instantiate(ground, new Vector2((curX + groundWidth), Mathf.PerlinNoise(seed, curY) * 5f), new Quaternion(0, 0, 0, 0));
            Debug.Log(Mathf.PerlinNoise(seed, curY) * 10);
            curY+=groundWidth;
            curX = curGround.transform.position.x;
        }
    }
}
