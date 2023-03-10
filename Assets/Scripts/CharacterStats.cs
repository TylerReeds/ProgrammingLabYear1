using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    public int damage;

    public event System.Action<int, int> OnHealthChanged;
    private void Start()
    {
        currentHp = maxHp;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "Died");
    }

    public virtual void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }
}
