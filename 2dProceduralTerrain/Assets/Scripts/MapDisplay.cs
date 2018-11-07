using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

    //public Renderer textureRenderer;
    //public MeshFilter meshFilter;
    //public MeshRenderer meshRenderer;

	public void DrawTexture(Texture2D texture, Renderer textureRenderer)
    {
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture, MeshFilter meshFilter, MeshRenderer meshRenderer, Renderer textureRenderer)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        //Debug.Log(meshRenderer);
        //meshRenderer.sharedMaterial.mainTexture = texture;

        Matrix4x4[] matrix = {
        new Matrix4x4(
        new Vector4(1,0,0,0),
        new Vector4(0,1,0,0),
        new Vector4(0,0,1,0),
        new Vector4(0,0,0,1)),
        new Matrix4x4(
        new Vector4(1,0,0,0),
        new Vector4(0,1,0,0),
        new Vector4(0,0,1,0),
        new Vector4(0,-70,0,1))
        };

        MeshExtrusion.ExtrudeMesh(meshFilter.sharedMesh, meshFilter.sharedMesh, matrix, false);
    }

    public void DrawNoiseMap(float[,] noiseMap, Renderer textureRenderer)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }
        texture.SetPixels(colorMap);
        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }

}
