using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public GameObject cameraOrbit;

    public float rotateSpeed = 8f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float h = rotateSpeed * Input.GetAxis("Horizontal");
            float v = rotateSpeed * Input.GetAxis("Vertical");
            float c;
            Debug.Log(v);
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    c = rotateSpeed;
            //}
            //else
            //{
            //    c = 0;
            //}
            cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x /*+ c*/, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);
        }

    }
}