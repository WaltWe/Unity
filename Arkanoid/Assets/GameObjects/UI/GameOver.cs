using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Lives").GetComponent<LivesScript>().lives <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
	}
}
