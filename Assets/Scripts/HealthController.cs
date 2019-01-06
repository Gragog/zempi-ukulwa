using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealthController : MonoBehaviour, IDamagable
{
    public int startHealth = 100;
    public byte startArmorAmount = 2;
    public float armorReduction = 0.5f;

    int currentHealth;
    byte currentArmorAmount;

    void Start()
    {
        currentHealth = startHealth;
        currentArmorAmount = startArmorAmount;
    }

    public bool DealDamage(int amount)
    {
        currentHealth -= (int)(amount * (1f - armorReduction));

        if (currentHealth <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
