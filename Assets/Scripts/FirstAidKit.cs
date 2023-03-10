using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private Collectables heart;

    private void Start()
    {
        heart = new Collectables("heart", 0, 5);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            heart.UpdateHealth();
            Destroy(gameObject);
        }
    }
}
