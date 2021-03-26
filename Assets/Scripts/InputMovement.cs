using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * movementZ + transform.right * movementX;

        if (movement.magnitude > Mathf.Epsilon) //Could crash from division by zero.
        {
            movement.Normalize();
            movement *= mySpeed * Time.deltaTime;
            gameObject.GetComponent<CharacterController>().Move(movement);
        }
    }

    public float mySpeed = 1f;

}