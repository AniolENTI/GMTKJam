using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float closedAngle = 0f;
    [SerializeField] private float doorSpeed = 45f; 

    [SerializeField] private Camera cam;
    private Collider doorCollider;
    private Plane[] cameraFrustum;

    private float currentAngle;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        doorCollider = GetComponent<Collider>();
        currentAngle = closedAngle;
    }

    void Update()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        bool isSeen = GeometryUtility.TestPlanesAABB(cameraFrustum, doorCollider.bounds);
        bool isHoldingSpace = Input.GetKey(KeyCode.Space);

        float targetAngle;

        if (isSeen && isHoldingSpace)
        {
            
            targetAngle = closedAngle;
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, doorSpeed * 1.50f * Time.deltaTime);
        }
        else
        {
            targetAngle = openAngle;
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, doorSpeed * Time.deltaTime);
        }
        
        transform.localRotation = Quaternion.Euler(0f, currentAngle, 0f);

        if (currentAngle == openAngle)
        {
            Debug.Log("Door is open");
            GameManager.Instance.SetGameLost(true);
        }

    }
}
