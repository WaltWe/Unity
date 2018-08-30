using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerUps {
    public static int force = 1;
    public static void clearAll()
    {
        GameObject.Find("Ball").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        GameObject.Find("Ball").GetComponent<TrailRenderer>().startColor = new Color(1, 1, 1);
        force = 1;
    }
}
