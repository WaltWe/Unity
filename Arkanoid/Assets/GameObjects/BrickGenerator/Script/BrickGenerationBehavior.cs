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
        for (int i = 0; i < (Camera.main.pixelWidth / (BrickPrefab.GetComponent<Renderer>().bounds.size.x * 25)); i++)
        {
            Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.6f) + (1.3f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {
        Bricks = GameObject.FindGameObjectsWithTag("Brick");
        //if(count == 0)
        //{
            for(int i = 0; i < (Camera.main.pixelWidth / (BrickPrefab.GetComponent<Renderer>().bounds.size.x * 25)); i++)
            {
                float bottomRowY = 0f;
                for (int j = 1; j < Bricks.Length; i++) {
                    if (Bricks[j].transform.position.y > Bricks[j - 1].transform.position.y)
                    {
                        bottomRowY = Bricks[j].transform.position.y;
                    }
                }
                if (bottomRowY > Camera.main.pixelHeight + .26f)
                {
                    Instantiate(BrickPrefab, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x * -1) + (.6f) + (1.3f * i), (Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) + .26f, 0), new Quaternion(0, 0, 0, 0));
                }
            }
            //count = 30;
        //}
        count--;
	}
}
