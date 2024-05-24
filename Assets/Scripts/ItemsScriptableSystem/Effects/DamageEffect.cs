using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : EffectsInterface
{
    private float damagePoints;

    public DamageEffect(float boost)
    {
        this.damagePoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.damage += damagePoints;
    }
}
