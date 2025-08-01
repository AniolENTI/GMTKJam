using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance { get; private set; }

    [SerializeField] private int totalEnergy = 100;

    private float currentMaxScore = 0.0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one GameManager" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        float currentMaxScore = PlayerPrefs.GetFloat("Score");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetTotalEnergy()
    {
        return totalEnergy;
    }

    public void SetTotalEnergy(int energy)
    {
        totalEnergy = energy;
    }

    public void ChangeScreen()
    {
        totalEnergy -= 10; 
    }

    public float GetTotalScore()
    {
        return currentMaxScore;
    }
}
