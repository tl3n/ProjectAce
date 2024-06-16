using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an effect that increases the player's damage.
/// </summary>
public class DamageEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// The amount of damage points to be added to the player's default damage.
    /// </summary>
    public float damagePoints;

    /// <summary>
    /// Initializes a new instance of the <see cref="DamageEffect"/> class with the specified damage points.
    /// </summary>
    /// <param name="boost">The amount of damage points to be added.</param>
    public DamageEffect(float boost)
    {
        this.damagePoints = boost;
    }

    /// <summary>
    /// Applies the damage effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        playerStats.defaultDamage += damagePoints;
    }
}
