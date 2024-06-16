using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for applying effects to player statistics.
/// </summary>
public interface EffectsInterface
{
    /// <summary>
    /// Applies the effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    void ApplyEffect(Stats playerStats);
}
