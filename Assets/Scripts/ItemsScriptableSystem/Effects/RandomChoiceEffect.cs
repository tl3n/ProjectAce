using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChoiceEffect : ScriptableObject, EffectsInterface
{
    private int[] randomIds;

    public void Initialize(int[] itemIdRange)
    {
        this.randomIds = itemIdRange;
    }

    public void ApplyEffect(Stats playerStats)
    {
        //playerStats.AddDamageModifier(GetRandomMultiplier());
    }

    /*private float GetRandomMultiplier()
    {
        int index = Random.Range(0, damageMultipliers.Length);
        return damageMultipliers[index];
    }*/
}
