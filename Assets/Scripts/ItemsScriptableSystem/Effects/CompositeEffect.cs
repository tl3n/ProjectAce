using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a composite effect that combines multiple effects and applies them to the player's stats.
/// </summary>
public class CompositeEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// A list of effects to be applied.
    /// </summary>
    private List<EffectsInterface> effects;

    /// <summary>
    /// Initializes the composite effect with a list of multiple effects.
    /// </summary>
    /// <param name="multipleEffects">A list of effects to be applied.</param>
    public void Initialize(List<EffectsInterface> multipleEffects)
    {
        this.effects = multipleEffects;
    }

    /// <summary>
    /// Applies all the combined effects to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effects will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        foreach (var effect in effects)
        {
            effect.ApplyEffect(playerStats);
        }
    }
}