using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public GameObject player;
    public GameObject[] terrain;
    private float terrPos = 0;
    private GameObject[] activeTerrain;
    public int viewDis;

    // Start is called before the first frame update
    void Start()
    {
        activeTerrain = new GameObject[viewDis];
        for (int i = 0; i < viewDis; i++)
        {
            int terrID = Random.Range(0, terrain.Length - 1);
            GameObject terrainPiece = Instantiate(terrain[terrID], new Vector3(0, 0, terrPos), Quaternion.identity);
            activeTerrain[i] = terrainPiece;
            terrPos += terrainPiece.GetComponent<Renderer>().bounds.size.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
