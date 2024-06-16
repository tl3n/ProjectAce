using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the UI display of player statistics such as health, speed, damage, and dodge chance.
/// </summary>
public class StatsUI : MonoBehaviour
{
    public Stats playerStats;                   // Reference to the player's Stats component
    public TextMeshProUGUI healthStatusText;    // Text element displaying health status
    public TextMeshProUGUI speedStatusText;     // Text element displaying speed status
    public TextMeshProUGUI damageStatusText;    // Text element displaying damage status
    public TextMeshProUGUI dodgeStatusText;     // Text element displaying dodge chance status

    void Start()
    {
        if (playerStats != null)
        {
            // Subscribe to the OnStatsChanged event to update UI when stats change
            playerStats.OnStatsChanged += UpdateUI;
            UpdateUI(); // Initial UI update
        }
    }

    private void OnDestroy()
    {
        if (playerStats != null)
        {
            // Unsubscribe from the OnStatsChanged event when this object is destroyed
            playerStats.OnStatsChanged -= UpdateUI;
        }
    }

    /// <summary>
    /// Updates the UI elements with current player statistics.
    /// </summary>
    void UpdateUI()
    {
        if (healthStatusText != null)
        {
            healthStatusText.text = "HEALTH: " + playerStats.currentHealth + "/" + playerStats.maxHealth;
        }
        if (speedStatusText != null)
        {
            speedStatusText.text = "SPEED: " + playerStats.speed;
        }
        if (damageStatusText != null)
        {
            damageStatusText.text = "DAMAGE: " + playerStats.defaultDamage;
        }

        if (dodgeStatusText != null)
        {
            dodgeStatusText.text = "DODGE CHANCE: " + playerStats.dodgeChance;
        }
    }
}
