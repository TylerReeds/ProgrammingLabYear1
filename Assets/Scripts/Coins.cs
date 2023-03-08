using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //public int score;
    Collectables coin;

    private void Awake()
    {
        coin = new Collectables("coin", 1, 0); 
    }

   private void OnCollisionEnter(Collision other)
     {
     if (other.gameObject.tag == "Player")
         {
         coin.UpdateScore();
         Destroy(gameObject);
         }
     }
}
