using UnityEngine;
using System.Collections;

public class Sled : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float turnSpeed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        characterController.Move(movement * Time.deltaTime * moveSpeed);
        if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }

    }
}