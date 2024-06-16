using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an effect that heals the player.
/// </summary>
public class HealingEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// The amount of health points to be added to the player's current health.
    /// </summary>
    public float healPoints;

    /// <summary>
    /// Initializes a new instance of the <see cref="HealingEffect"/> class with the specified healing points.
    /// </summary>
    /// <param name="boost">The amount of health points to be added.</param>
    public HealingEffect(float boost)
    {
        this.healPoints = boost;
    }

    /// <summary>
    /// Applies the healing effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        playerStats.currentHealth += healPoints;
        if (playerStats.currentHealth > playerStats.maxHealth)
        {
            playerStats.currentHealth = playerStats.maxHealth;
        }
    }
}
