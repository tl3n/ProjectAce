using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Represents an effect that boosts the player's speed.
/// </summary>
public class SpeedEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// The amount of speed points to be added to the player's speed.
    /// </summary>
    public float speedPoints;

    /// <summary>
    /// Initializes a new instance of the SpeedEffect class with the specified speed boost.
    /// </summary>
    /// <param name="boost">The amount of speed points to be added.</param>
    public SpeedEffect(float boost)
    {
        this.speedPoints = boost;
    }

    /// <summary>
    /// Applies the speed boost effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        playerStats.speed += speedPoints;
    }
}
