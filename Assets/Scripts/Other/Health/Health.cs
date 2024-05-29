using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public int currentHealth, maxHealth;

    [SerializeField] private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void InitializeHealth(int health)
    {
        currentHealth = health;
        maxHealth = health;
        isDead = false;
    }

    public void GetHit(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth < amount)
        {
            isDead = true;
        }
    }
}

