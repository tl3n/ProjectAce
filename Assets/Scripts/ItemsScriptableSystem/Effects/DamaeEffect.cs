using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamaeEffect : EffectsInterface
{
    private float damagePoints;

    public void IncreaseDamage(float boost)
    {
        this.damagePoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.damage += damagePoints;
    }
}
