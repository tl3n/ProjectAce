using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : ScriptableObject, EffectsInterface
{
    public float damagePoints;

    public DamageEffect(float boost)
    {
        this.damagePoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.defaultDamage += damagePoints;
    }
}
