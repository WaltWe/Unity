using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerUps {
    public static int force = 1;
    public static float speed = 0;
    public static void clearAll()
    {
        if (speed > 0) { GameObject.Find("Ball").GetComponent<Rigidbody>().velocity = new Vector3(GameObject.Find("Ball").GetComponent<Rigidbody>().velocity.x / speed, GameObject.Find("Ball").GetComponent<Rigidbody>().velocity.y / speed, 0); }
        GameObject.Find("Ball").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        GameObject.Find("Ball").GetComponent<TrailRenderer>().startColor = new Color(1, 1, 1);
        force = 1;
        speed = 0;
    }
    public static void explode()
    {
        GameObject[] Bricks = GameObject.FindGameObjectsWithTag("Brick");
        for(int i = 0; i < Bricks.Length; i++)
        {
            Bricks[i].GetComponent<BrickScript>().hitCount--;
        }
    }
}
