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
        leftX = -((-alienWidth + .5f) * maxCol);
        topY = Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,0)).y - alienWidth/2 - 1;

        Aliens = new GameObject[maxRow, maxCol];

        //makeAliens();

        //GetComponent<Rigidbody2D>().velocity = new Vector3(-3, 0, 0);
    }

    private void Update()
    {
        if (!Stats.pause && Stats.level <= 11)
        {
            if(GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(-3, 0, 0);
            }
            if (transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - alienWidth * maxCol - alienWidth + .5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(3, 0, 0);
            }
            else if (transform.position.x > -(-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - alienWidth * maxCol - alienWidth + .5))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(-3, 0, 0);
            }
        }
        else if (Stats.level > 11)
        {
            if (GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(-6, 0, 0);
            }
            if (transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - alienWidth * maxCol - alienWidth + .5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(6, 0, 0);
            }
            else if (transform.position.x > -(-Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x - alienWidth * maxCol - alienWidth + .5))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(-6, 0, 0);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
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
                alien.GetComponent<Alien>().maxCol = maxCol;
                alien.GetComponent<Alien>().maxRow = maxRow;
                alien.GetComponent<Alien>().level = Stats.level;
                GameObject.Find("LevelManager").GetComponent<LevelManager>().alienCount++;
                Aliens[row, col] = alien;
            }
        }
    }
    public void deleteAliens()
    {
        transform.position = new Vector3(0, 0, 0);
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
    public void makeBoss()
    {
        deleteAliens();
        maxRow = Stats.level - 11;
        maxCol = Stats.level - 11;
        leftX = -((-alienWidth + .5f) * maxCol);
        for (int row = 0; row < maxRow; row++)
        {
            for (int col = 0; col < maxCol; col++)
            {
                GameObject alien = Instantiate(Alien, new Vector2(leftX + (row + 1) * (-alienWidth + .5f), topY + (col + 1) * (alienHeight - .5f)), new Quaternion(0, 0, 0, 0));
                alien.transform.parent = this.transform;
                alien.GetComponent<Alien>().Row = row + 1;
                alien.GetComponent<Alien>().Col = col + 1;
                alien.GetComponent<Alien>().maxCol = maxCol;
                alien.GetComponent<Alien>().maxRow = maxRow;
                alien.GetComponent<Alien>().level = Stats.level;
                GameObject.Find("LevelManager").GetComponent<LevelManager>().alienCount++;
                Aliens[row, col] = alien;
            }
        }
    }
}
