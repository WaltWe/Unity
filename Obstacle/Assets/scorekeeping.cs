using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorekeeping : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Transform>().position.z < 100)
        {
            GetComponent<Text>().text = "Score: " + ((int)player.GetComponent<Transform>().position.z / 10) % 10;
        }
        else
        {
            GetComponent<Text>().text = "You Win!";
        }
    }
}
