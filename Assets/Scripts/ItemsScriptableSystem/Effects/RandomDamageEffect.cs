using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDamageEffect : ScriptableObject, EffectsInterface
{
    private float[] damageMultipliers;

    public void Initialize(float[] multipliers)
    {
        this.damageMultipliers = multipliers;
    }

    public void ApplyEffect(Stats playerStats)
    {
       playerStats.AddDamageModifier(GetRandomMultiplier());   
    }

    private float GetRandomMultiplier()
    {
        int index = Random.Range(0, damageMultipliers.Length);
        return damageMultipliers[index];
    }
}
