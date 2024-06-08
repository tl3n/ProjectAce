using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHPAmplifyEffect : ScriptableObject, EffectsInterface
{
    public float hpAmplifyPoints;

    public MaxHPAmplifyEffect(float boost)
    {
        this.hpAmplifyPoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.maxHealth += hpAmplifyPoints;
        playerStats.currentHealth += hpAmplifyPoints;
    }
}
