using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    int totalScore = 0;

    private void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = this; 
        }

        scoreText.text = "Score: 0"; 
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        Debug.Log(totalScore);
        scoreText.text = "Score: " + totalScore.ToString(); 
    }
}
