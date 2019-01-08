using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public static class playerdata
{
    public static bool hasSuit  = false;
    public static bool hasHeat  = false;
    public static bool hasGun   = false;
    public static bool hasRPG   = false;
    public static bool hasBoots = false;

    public static Vector2 gravity  = new Vector2(0, -1);
    public static Vector2 terminal = new Vector2(8, 16);

    public static int health = 100;
}
public class playerBehaviourScript : MonoBehaviour {

    public bool grounded = true;
    private float[] vert = new float[20];
    
	void Start () {

	}
	
	void Update () {

        if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > playerdata.terminal.y)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2 (this.GetComponent<Rigidbody2D>().velocity.x, playerdata.terminal.y * this.GetComponent<Rigidbody2D>().velocity.y / Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y));
        } else
        {
            this.GetComponent<Rigidbody2D>().velocity += playerdata.gravity;
        }
        if (!walkChack())
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerdata.terminal.x * Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) * -1, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = walkVector();
        }
        
     }

}
*/