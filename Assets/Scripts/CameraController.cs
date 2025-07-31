using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;

    float rotationX;
    float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor

        orientation.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Initialize orientation rotation
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        rotationX += mouseX;
        //rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp rotation to prevent flipping

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Clamp rotation to prevent flipping

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
        orientation.rotation = Quaternion.Euler(0f, rotationX, 0f);
    }
}
