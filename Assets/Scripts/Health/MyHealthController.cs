using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthController : MonoBehaviour, IDamagable
{
    public int startHealth = 100;
    public byte startArmorAmount = 2;
    public float armorReduction = 0.5f;

    public Image healthBar;
    public ShieldPanelUI shieldUI;
    public GameObject shieldSegment;

    int currentHealth;
    byte currentArmorAmount;

    void Start()
    {
        currentHealth = startHealth;
        currentArmorAmount = startArmorAmount;

        if (healthBar)
        {
            shieldUI.shieldSegment = shieldSegment;
            shieldUI.CreateSegments(startArmorAmount);
            UpdateUI();

            return;
        }

        Debug.LogError("No Healthbar image given");
    }

    void UpdateUI()
    {
        healthBar.fillAmount = (float)currentHealth / startHealth;
    }

    public bool DealDamage(int amount)
    {
        float newAmount = amount;
        byte shieldDamage = 1;

        if (currentArmorAmount > 0)
        {
            newAmount *= 1f - armorReduction;
            currentArmorAmount -= shieldDamage;
            shieldUI.RemoveSegments(shieldDamage);
        }

        currentHealth -= (int)newAmount;
        UpdateUI();

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
