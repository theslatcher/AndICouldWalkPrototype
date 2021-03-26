using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * myMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * myMouseSensitivity * Time.deltaTime;

        myXRotation -= mouseY;
        myXRotation = Mathf.Clamp(myXRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(myXRotation, 0f, 0f);
        myPlayerBodyTransform.Rotate(Vector3.up * mouseX);
    }

    public float myMouseSensitivity = 100f;
    public Transform myPlayerBodyTransform;

    private float myXRotation = 0f;

}
