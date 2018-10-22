using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Score").GetComponent<TextMesh>().text = "Score: " + Stats.score;
        GameObject.Find("Lives").GetComponent<TextMesh>().text = "Lives: " + Stats.lives;
    }
}
