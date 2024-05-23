using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffect : EffectsInterface
{
    private float healPoints;

    public void IncreaseHeal(float boost)
    {
        this.healPoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.health += healPoints;
    }
}
