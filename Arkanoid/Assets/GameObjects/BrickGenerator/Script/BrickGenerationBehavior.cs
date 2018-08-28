using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerationBehavior : MonoBehaviour {
    public int count = 0;
    static int brickWidth;
    public GameObject BrickPrefab;
    public GameObject[] Bricks;
    // Use this for initialization
    void Start() {
        Debug.Log(GameObject.Find("Brick").GetComponent<SpriteRenderer>().size.x);
        for (int i = 0; i < (Camera.main.pixelWidth / (((Camera.main.pixelWidth / 16.0f) / 32.0f) * 32)); i++)
        {
            if (Mathf.Abs(Camera.main.aspect - (9f / 16f)) < .001)
            {
                Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.3f) + (.6f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (Mathf.Abs(Camera.main.aspect - (16f / 9f)) < .001)
            {
                Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.6f) + (1.3f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Bricks = GameObject.FindGameObjectsWithTag("Brick");
        float topRowY = 0f;
        for(int i = 0; i < Bricks.Length - 1; i++)
        {
            if (Bricks[i].transform.position.y > topRowY)
            {
                topRowY = Bricks[i].transform.position.y;
            }
        }
        for (int i = 0; i < (Camera.main.pixelWidth / (BrickPrefab.GetComponent<Renderer>().bounds.size.x)); i++)
        {
            if (topRowY < ((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelHeight, 0, 0)).y * -1) - .4f))
            {
                if (Mathf.Abs(Camera.main.aspect - (9f / 16f)) < .001)
                {
                    Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.3f) + (.6f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
                }
                if(Mathf.Abs(Camera.main.aspect - (16f / 9f)) < .001)
                {
                    Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.6f) + (1.3f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
                }
            }
        }
	}
}
