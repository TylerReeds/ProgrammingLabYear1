using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour, IDataPersistance
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    int totalScore = 0;

    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = this; 
        }
    }

    private void Start()
    {
        scoreText.text = "Score: " + totalScore.ToString();
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        Debug.Log(totalScore);
        scoreText.text = "Score: " + totalScore.ToString(); 
    }
    public void SaveData(ref GameData data)
    {
        data.score = this.totalScore;
    }

    public void LoadData(GameData data)
    {
        this.totalScore = data.score;
    }
}
