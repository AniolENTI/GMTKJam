using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public UnityEngine.Material screenMaterial;
    public UnityEngine.Texture baseImage;
    public UnityEngine.Texture[] alteredImageArray;

    bool changed = false;

    [SerializeField] private Camera cam;
    private Plane[] cameraFrustrum;
    private Collider collider;


    [SerializeField] private float timerMax = 10.0f; 
    [SerializeField] private float timerMin = 5.0f; 
    [SerializeField] private float timer = 0.0f;

    [SerializeField] private float loseTimerTotal = 10.0f;
    [SerializeField] private float loseTimer = 10.0f;

    [SerializeField] private float score = 0.0f;

    bool lost = false;

    void Start()
    {
        GameObject aux = GameObject.FindGameObjectWithTag("MainCamera");
        cam = aux.GetComponent<Camera>();
        collider = GetComponent<Collider>();
        screenMaterial.SetTexture("_MainTex", baseImage);

        timer = Random.Range(timerMin, timerMax); 
    }

    void Update()
    {
        if (/*Input.GetKeyUp(KeyCode.Space)*/ timer <= 0 && !changed)
        {
            int aux = Random.Range(0, 100);

            if (aux < 50)
            {
                if (screenMaterial.GetTexture("_MainTex") == baseImage)
                {
                    UnityEngine.Texture auxTexture;
                    int auxLength = alteredImageArray.Length;
                    auxTexture = alteredImageArray[Random.Range(0, auxLength)];
                    screenMaterial.SetTexture("_MainTex", auxTexture);
                }
                else
                    screenMaterial.SetTexture("_MainTex", baseImage);

                changed = true;
            }
        }

        if (cam != null)
        {
            cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(cam);
        }
        else
        {
            GameObject aux = GameObject.FindGameObjectWithTag("MainCamera");
            cam = aux.GetComponent<Camera>();
        }

        if (!IsInCameraNow())
        {
            timer -= Time.deltaTime;
        }
        else if (IsInCameraNow())
        {
            timer = Random.Range(timerMin, timerMax);
        }

        if (changed)
        {
            loseTimer -= Time.deltaTime;
            if (loseTimer <= 0)
            {
                Debug.Log("You lost! Timer ran out.");
                lost = true;
            }

            if (Input.GetKeyUp(KeyCode.Space) && GameManager.Instance.GetTotalEnergy() >= 10.0f && IsInCameraNow())
            {
                changed = false;
                loseTimer = loseTimerTotal;
                screenMaterial.SetTexture("_MainTex", baseImage);
                GameManager.Instance.ChangeScreen();
            }
        }

        if (!lost)
        {
            score += Time.deltaTime;
        }
        else
        {
            if (GameManager.Instance.GetTotalScore() < score)
            {
                PlayerPrefs.SetFloat("Score", score);
                PlayerPrefs.Save();
            }
        }
    }
    public bool IsInCameraNow()
    {
        var bounds = collider.bounds;
        return GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds);
    }
}
