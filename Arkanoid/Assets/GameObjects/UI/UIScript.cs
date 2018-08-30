using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {
    public int score = 0;
	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "Score: " + score;
        Stats.Score = score;
	}
}
