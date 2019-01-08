using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class playerdata
{
    public static bool hasSuit = true;
    public static bool hasEVA = false;
    public static bool hasHeat = false;
    public static bool hasGun = false;
    public static bool hasBoots = false;

    public static bool bootsPower = false;

    public static Vector2 gravity = new Vector2(0,-10);
    public static Vector2 terminal = new Vector2(120, 80000000000000000);

    public static Vector2 localGravity = new Vector2(0, -10);
    public static Vector2 magneticGravity = new Vector2(0, 10);


    public static int health = 100;
}

public class newPlayerBehaviourScript : MonoBehaviour {

    private float[] vertVelocity = new float[2];
    public float jumpMargin;

    void Start()
    {
        playerdata.gravity = playerdata.localGravity;
    }

    private void Update()
    {
        powerUpBehaviour();
        if (Mathf.Abs(playerdata.gravity.x) + Mathf.Abs(playerdata.gravity.y) > 0) {
            walking();
            jumping();
            gravity();
            applyTerminal();
        } else
        {
            if (playerdata.hasEVA)
                this.GetComponent<Rigidbody2D>().velocity += new Vector2(Input.GetAxis("Horizontal") * 10, Input.GetAxis("Vertical") * 10);
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerdata.terminal.y * getNegative(this.GetComponent<Rigidbody2D>().velocity.x), this.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, playerdata.terminal.y * getNegative(this.GetComponent<Rigidbody2D>().velocity.y));
            }
        }
    }
    void walking()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01)
        {
            this.GetComponent<Rigidbody2D>().velocity += Vector2.Perpendicular(new Vector2(playerdata.gravity.x * Input.GetAxis("Horizontal") * 10 * getNegative(playerdata.gravity.x), playerdata.gravity.y * Input.GetAxis("Horizontal") * 10 * getNegative(playerdata.gravity.x)));
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity -= Vector2.Perpendicular(new Vector2(playerdata.gravity.x * 10, playerdata.gravity.y * Input.GetAxis("Horizontal") * 10));
        }
    }
    void gravity()
    {
        if (playerdata.gravity.y != 0)
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) < playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity += playerdata.gravity;
            } else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, playerdata.terminal.y * playerdata.gravity.y);
            }
        } else
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) < playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity += playerdata.gravity;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerdata.terminal.y * playerdata.gravity.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
    void jumping()
    {
        bool canJump = jumpCheck();
        if (canJump)
        {
            if (Input.GetKeyDown("space")) {
                this.GetComponent<Rigidbody2D>().velocity += new Vector2(playerdata.gravity.x * -50, playerdata.gravity.y * -50);
            }
        }
    }
    void applyTerminal()
    {
        if (playerdata.gravity.y != 0)
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > playerdata.terminal.x)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerdata.terminal.x * this.GetComponent<Rigidbody2D>().velocity.x / Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x), this.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, playerdata.terminal.y * this.GetComponent<Rigidbody2D>().velocity.y / Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y));
            }
        } else
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > playerdata.terminal.x)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(playerdata.terminal.y * getNegative(this.GetComponent<Rigidbody2D>().velocity.x), this.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > playerdata.terminal.y)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, playerdata.terminal.x * getNegative(this.GetComponent<Rigidbody2D>().velocity.y));
            }
        }
    }
    bool jumpCheck()
    {
        bool check = true;
        for (int i = 1; i < vertVelocity.Length; i++)
        {
            vertVelocity[i - 1] = vertVelocity[i];
            if (Mathf.Abs(vertVelocity[i]) > jumpMargin) check = false;
        }
        vertVelocity[0] = this.GetComponent<Rigidbody2D>().velocity.y * playerdata.gravity.y + this.GetComponent<Rigidbody2D>().velocity.x * playerdata.gravity.x;
        if (Mathf.Abs(vertVelocity[0]) > jumpMargin) check = false;
        return check;
    }
    float getNegative(float input)
    {
        if (input < 0)
        {
            return -1;
        }
        return 1;
    }
    static void powerUpBehaviour()
    {
        if (Input.GetKeyDown("s") && playerdata.hasBoots) {
            Debug.Log("Boots power is " + !playerdata.bootsPower);
            playerdata.bootsPower = !playerdata.bootsPower;
            if (playerdata.bootsPower) playerdata.gravity = playerdata.magneticGravity;
            else playerdata.gravity = playerdata.localGravity;
            Debug.Log(playerdata.gravity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "powerUp")
        {
            if (collision.gameObject.name == "spaceSuit")
            {
                playerdata.hasSuit = true;
            }
            else if (collision.gameObject.name == "evaModule")
            {
                playerdata.hasEVA = true;
            }
            else if (collision.gameObject.name == "heatSuit")
            {
                playerdata.hasHeat = true;
            }
            else if (collision.gameObject.name == "gun")
            {
                playerdata.hasGun = true;
            }
            else if (collision.gameObject.name == "magneticBoots")
            {
                playerdata.hasBoots = true;
                Debug.Log("You now have magnetic boots!");
            }
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "gravity down")
            playerdata.localGravity = new Vector2(0, -1);
        else if (collision.gameObject.tag == "gravity up")
            playerdata.localGravity = new Vector2(0, 1);
        else if (collision.gameObject.tag == "gravity left")
            playerdata.localGravity = new Vector2(-1, 0);
        else if (collision.gameObject.tag == "gravity right")
            playerdata.localGravity = new Vector2(1, 0);

        if (collision.gameObject.tag == "magnetic gravity down")
            playerdata.localGravity = new Vector2(0, -1);
        else if (collision.gameObject.tag == "magnetic gravity up")
        {
            playerdata.magneticGravity = new Vector2(0, 1);
        }
        else if (collision.gameObject.tag == "magnetic gravity left")
            playerdata.magneticGravity = new Vector2(-1, 0);
        else if (collision.gameObject.tag == "magnetic gravity right")
            playerdata.magneticGravity = new Vector2(1, 0);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "gravity down")
            playerdata.localGravity = new Vector2(0, 0);
        else if (collision.gameObject.tag == "gravity up")
            playerdata.localGravity = new Vector2(0, 0);
        else if (collision.gameObject.tag == "gravity left")
            playerdata.localGravity = new Vector2(0, 0);
        else if (collision.gameObject.tag == "gravity right")
            playerdata.localGravity = new Vector2(0, 0);
        if (collision.gameObject.tag == "magnetic gravity down")
            playerdata.localGravity = new Vector2(0, 0);
        else if (collision.gameObject.tag == "magnetic gravity up")
            playerdata.magneticGravity = new Vector2(0, 1);
        else if (collision.gameObject.tag == "magnetic gravity left")
            playerdata.magneticGravity = new Vector2(-1, 0);
        else if (collision.gameObject.tag == "magnetic gravity right")
            playerdata.magneticGravity = new Vector2(1, 0);
    }
}