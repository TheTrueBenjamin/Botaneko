using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float rotationSpeed = 5.0f; // The speed of rotation
    public float distance = 20.0f; // Distance from the target
    public float lerpSpeed = 1.0f; // Speed of the lerp/smooth effect

    // Clamping angles for Y rotation
    public float minYAngle = 10.0f;
    public float maxYAngle = 80.0f;

    // Clamping angles for X rotation
    public float minXAngle = -90.0f;
    public float maxXAngle = 0.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Start()
    {
        // This will give the camera's current rotation in terms of angles
        currentX = transform.eulerAngles.y;
        currentY = transform.eulerAngles.x;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Fetch the input from the user
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            // Clamp the X and Y rotations
            currentX = Mathf.Clamp(currentX, minXAngle, maxXAngle);
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
        }

        // Calculate the desired rotation and position
        Quaternion desiredRotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = desiredRotation * new Vector3(0, 0, -distance) + target.position;

        // Lerp to the desired rotation and position
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, lerpSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpSpeed * Time.deltaTime);
    }
}
