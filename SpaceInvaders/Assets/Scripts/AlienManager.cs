using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour{

    public GameObject Alien;

    public static int maxRow;
    public static int maxCol;
    public static float leftX;
    public static float topY;
    public static float alienWidth;
    public static float alienHeight;
    public GameObject[,] Aliens;

    private void Start()
    {
        maxRow = ((int)(Camera.main.pixelWidth / (Camera.main.WorldToScreenPoint(new Vector3(Alien.GetComponent<Renderer>().bounds.size.x, 0, 0)).x / 10))) - 8;
        maxCol = ((int)(Camera.main.pixelHeight / (Camera.main.WorldToScreenPoint(new Vector3(Alien.GetComponent<Renderer>().bounds.size.y, 0, 0)).x / 10))) - 2;
        alienWidth = Camera.main.ScreenToWorldPoint(new Vector3(Alien.GetComponent<Renderer>().bounds.size.x, 0, 0)).x/10;
        alienHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Alien.GetComponent<Renderer>().bounds.size.y, 0)).y/10;
        leftX = ((-alienWidth + .5f) * maxCol);
        topY = Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,0)).y - alienWidth/2;
        
        Aliens = new GameObject[maxRow, maxCol];

        makeAliens();

        GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0);
    }

    private void Update()
    {
        if(transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x -leftX)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);
        }
    }

    public void makeAliens()
    {
        deleteAliens();
        for(int row = 0; row < maxRow; row++)
        {
            for(int col = 0; col < maxCol; col++)
            {
                GameObject alien = Instantiate(Alien, new Vector2(leftX + (row + 1) * (-alienWidth+.5f), topY + (col + 1) * (alienHeight-.5f)), new Quaternion(0, 0, 0, 0));
                alien.transform.parent = this.transform;
                alien.GetComponent<Alien>().Row = row+1;
                alien.GetComponent<Alien>().Col = col+1;
                alien.GetComponent<Alien>().level = GameObject.Find("LevelManager").GetComponent<LevelManager>().Level;
                Aliens[row, col] = alien;
            }
        }
    }
    public void deleteAliens()
    {
        for(int row = 0; row < maxRow; row++)
        {
            for(int col = 0; col < maxCol; col++)
            {
                if (Aliens[row, col] != null)
                {
                    DestroyObject(Aliens[row, col]);
                    Aliens[row, col] = null;
                }
            }
        }
    }
}
