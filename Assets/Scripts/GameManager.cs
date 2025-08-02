using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance { get; private set; }

    [SerializeField] private int totalEnergy = 100;

    private float currentMaxScore = 0.0f;
    private float score;

    bool gameLost = false;

    public GameObject energyText;
    public GameObject scoreText;

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
        float currentMaxScore = PlayerPrefs.GetFloat("Time");
    }

    // Update is called once per frame
    void Update()
    {
        energyText.GetComponent<TextMeshProUGUI>().text = "Energy: " + totalEnergy.ToString("F2");
        scoreText.GetComponent<TextMeshProUGUI>().text = "Time: " + score.ToString("F2");

        if (!gameLost)
        {
            score += Time.deltaTime;
        }
        else
        {
            if (currentMaxScore < score)
            {
                PlayerPrefs.SetFloat("Time", score);
                PlayerPrefs.Save();
            }
        }
    }

    public int GetTotalEnergy()
    {
        return totalEnergy;
    }

    public void SetTotalEnergy(int energy)
    {
        totalEnergy = energy;
    }

    public void LosePower()
    {
        totalEnergy -= 10; 
    }

    public float GetTotalScore()
    {
        return currentMaxScore;
    }

    public void SetGameLost(bool lost)
    {
        gameLost = lost;
    }
}
