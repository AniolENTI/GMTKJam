using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Roulette : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Plane[] cameraFrustrum;
    private Collider collider;

    private bool isSpinning = false;

    [Header("Ruleta")]
    [SerializeField] private int numberOfSections = 8;
    [SerializeField] private float spinDuration = 2f;
    [SerializeField] private int extraSpins = 3;

    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private string[] rewards;


    void Start()
    {
        if (cam == null)
        {
            GameObject aux = GameObject.FindGameObjectWithTag("MainCamera");
            cam = aux.GetComponent<Camera>();
        }
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(cam);

        if (Input.GetKeyDown(KeyCode.Space) && IsInCameraNow() && !isSpinning)
        {            
            StartCoroutine(SpinToRandomSection());
        }
    }

    public bool IsInCameraNow()
    {
        var bounds = collider.bounds;
        return GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds);
    }

    private IEnumerator SpinToRandomSection()
    {
        isSpinning = true;

        int targetSection = Random.Range(0, numberOfSections);
        float sectionAngle = 360f / numberOfSections;
        float targetAngle = sectionAngle * targetSection;

        float totalRotation = 360f * extraSpins + targetAngle;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, totalRotation, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            t = Mathf.SmoothStep(0f, 1f, t); 
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        transform.rotation = endRotation;
        Debug.Log($"The roulette stopped at: {targetSection}");
        isSpinning = false;
    }
}
