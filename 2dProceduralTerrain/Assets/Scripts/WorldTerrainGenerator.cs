using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTerrainGenerator : MonoBehaviour {

    public float X;
    public float chunkWidth;
    public GameObject chunk;
    public float curX;
    public float leftX;

	// Use this for initialization
	void Start () {
        X = GetComponentInParent<Transform>().position.x;
        leftX = Camera.main.ScreenToWorldPoint(new Vector3(-Camera.main.pixelWidth / 2, 0, 0)).x / 2;
        GameObject newChunk = Instantiate(chunk, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)); ;
        curX = newChunk.transform.position.x;
        FindObjectOfType<MapGenerator>().GenerateMap(newChunk.GetComponent<MeshFilter>(), newChunk.GetComponent<MeshRenderer>(), newChunk.GetComponent<Renderer>(), 0);
        newChunk.AddComponent<MeshCollider>();
        chunkWidth = newChunk.GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update () {
        X = GetComponentInParent<Transform>().position.x;
        if (curX - X <= leftX)
        {
            GameObject newChunk = Instantiate(chunk, new Vector2((curX + chunkWidth), 0), new Quaternion(0, 0, 0, 0));
            curX = newChunk.transform.position.x;
            FindObjectOfType<MapGenerator>().GenerateMap(newChunk.GetComponent<MeshFilter>(), newChunk.GetComponent<MeshRenderer>(), newChunk.GetComponent<Renderer>(), curX+chunkWidth);
            GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
            if (chunks.Length > 2)
            {
                float minX = float.MaxValue;
                GameObject lastChunk = null;
                for (int i = 0; i < chunks.Length; i++)
                {
                    if (chunks[i].transform.position.x < minX)
                    {
                        minX = chunks[i].transform.position.x;
                        lastChunk = chunks[i];
                    }
                }
                Destroy(lastChunk.gameObject);
            }
        }
    }
}
