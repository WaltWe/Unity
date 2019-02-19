using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-15, 0, 0), ForceMode.Impulse);
        }
    }
}
