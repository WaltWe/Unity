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
            Debug.Log(cameraOrbit.transform.eulerAngles);
            cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);
        }

    }
}