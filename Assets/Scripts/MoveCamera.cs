using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position; // Update the camera's position to match the cameraPosition transform
    }
}
