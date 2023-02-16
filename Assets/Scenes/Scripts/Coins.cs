using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int score;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.scoreManager.UpdateScore(score);
            Debug.Log("Coin Collected");
            Destroy(gameObject);
        }
    }
}
