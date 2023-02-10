using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    public int damage;

    private void Start()
    {
        currentHp = 0;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "Died");
    }

    public virtual void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHp -= damage;

        if (currentHp < 0)
        {
            Die();
        }
    }
}
