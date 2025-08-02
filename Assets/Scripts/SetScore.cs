using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{

    public GameObject scoreText;

    [SerializeField] private float score = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("Score");

        
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString("F2");


    }
}
