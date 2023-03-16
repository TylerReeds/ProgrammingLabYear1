using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    public int damage;
    private int currentHp; 

    public int CurrentHealth
    {
        get 
        {
            return currentHp; 
        }
    }
    public event System.Action<int, int> OnHealthChanged;
    private void Start()
    {
        currentHp = maxHp;
        StartCoroutine(HealthIncrease());
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "Died");
    }

    public virtual void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHp -= damage;

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHp, currentHp);
        }
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public virtual void RestoreHealth(int restore)
    { 
        currentHp = Mathf.Clamp(currentHp + restore, 0, maxHp);

        Debug.Log(currentHp);

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHp, currentHp);
        }
    }
    IEnumerator HealthIncrease()
    {
        Debug.Log("Start Coroutine");

        for (int x = 1; x <= maxHp; x++)
        {
            currentHp = x;
            if (OnHealthChanged != null)
            {
                OnHealthChanged(maxHp, currentHp);
            }

            yield return new WaitForSeconds(0.01f);
            Debug.Log("HP: " + currentHp + " / " + maxHp);
        }

        Debug.Log("The current health is " + currentHp);
        Debug.Log("End Coroutine");
    }
}
