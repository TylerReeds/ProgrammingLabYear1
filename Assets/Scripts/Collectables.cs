using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string nameCollectable;
    public int scoreCollectable;
    public int restoreHP; 

    public Collectables(string name, int score, int restoreHPValue)
    {
        this.nameCollectable = name; 
        this.scoreCollectable = score;
        this.restoreHP = restoreHPValue;    
    }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(scoreCollectable); 
    }
}
