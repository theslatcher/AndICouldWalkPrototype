using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private CharacterController myCharacterController = null;

    void Awake()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movement = transform.forward * Input.GetAxis("Vertical");
        movement += transform.right * Input.GetAxis("Horizontal");

        if (movement.sqrMagnitude > 1f)
            movement.Normalize();

        myCharacterController.SimpleMove(movement * myMovementSpeed);
    }

    public float myMovementSpeed = 1f;

}