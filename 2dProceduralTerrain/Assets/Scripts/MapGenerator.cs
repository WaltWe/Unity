using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    public enum DrawMode { NoiseMap, Mesh}
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    public bool autoUpdate;
    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;
    public float meshHeightMultiplier;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed,noiseScale,octaves,persistance,lacunarity,offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if(drawMode == DrawMode.NoiseMap)
        {
            display.DrawNoiseMap(noiseMap);
        }else if(drawMode == DrawMode.Mesh){
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap,meshHeightMultiplier), TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        
    }

    private void OnValidate()
    {
        if(mapWidth < 1)
        {
            mapWidth = 1;
        }
        if(mapHeight < 1)
        {
            mapWidth = 1;
        }
        if(lacunarity < 1)
        {
            lacunarity = 1;
        }
        if(octaves < 0)
        {
            octaves = 0;
        }
    }
}
