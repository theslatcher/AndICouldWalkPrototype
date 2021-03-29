using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GroundDetector : MonoBehaviour
{
    private bool myIsGrounded = true;
    public bool Grounded => myIsGrounded;
    private float myDistToGround = 1f;
    private CharacterController myCharacterController = null;

    void Awake()
    {
        myIsGrounded = true;
        myCharacterController = GetComponent<CharacterController>();
        myDistToGround = myCharacterController.bounds.min.y;
    }

    void Start()
    {
        myDistToGround = Mathf.Abs(transform.position.y - myCharacterController.bounds.min.y);
    }

    private void FixedUpdate()
    {
        myIsGrounded = GroundCheck();
    }

    bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, myDistToGround + 0.1f);
    }
}
