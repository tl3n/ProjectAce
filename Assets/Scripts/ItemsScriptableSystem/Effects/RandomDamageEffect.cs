using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an effect that applies a random damage multiplier to the player's damage.
/// </summary>
public class RandomDamageEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// Array of damage multipliers to choose from.
    /// </summary>
    private float[] damageMultipliers;

    /// <summary>
    /// Initializes the effect with an array of damage multipliers.
    /// </summary>
    /// <param name="multipliers">Array of damage multipliers to choose from.</param>
    public void Initialize(float[] multipliers)
    {
        this.damageMultipliers = multipliers;
    }

    /// <summary>
    /// Applies the random damage multiplier effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        playerStats.AddDamageModifier(GetRandomMultiplier());
    }

    /// <summary>
    /// Returns a random damage multiplier from the array of multipliers.
    /// </summary>
    /// <returns>A random damage multiplier.</returns>
    private float GetRandomMultiplier()
    {
        int index = Random.Range(0, damageMultipliers.Length);
        return damageMultipliers[index];
    }
}
