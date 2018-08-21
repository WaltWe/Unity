using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<TextMesh>().color = new Color(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        int hits = GetComponentInParent<BrickScript>().hitCount;
        GetComponent<TextMesh>().text = hits.ToString();
	}
}
