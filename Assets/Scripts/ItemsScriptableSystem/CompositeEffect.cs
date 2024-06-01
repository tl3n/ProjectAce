using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeEffect : ScriptableObject, EffectsInterface
{
    private List<EffectsInterface> effects;

    public void Initialize(List<EffectsInterface> multipleEffects)
    {
        this.effects = multipleEffects;
    }

    public void ApplyEffect(Stats playerStats)
    {
        foreach (var effect in effects)
        {
            effect.ApplyEffect(playerStats);
        }
    }
}