using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Click()
    {
        GameObject.Find("player").GetComponent<player>().moveright = true;
    }
    
    public void stopClick()
    {
        GameObject.Find("player").GetComponent<player>().moveright = false;
    }

    public void jump()
    {
        GameObject.Find("player").GetComponent<player>().jump = true;
    }
    
    public void jumpStop()
    {
        GameObject.Find("player").GetComponent<player>().jump = false;
    }
}
