using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeEffect : ScriptableObject, EffectsInterface
{
    public float dodgePoints;

    public DodgeEffect(float boost)
    {
        this.dodgePoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.dodgeChance += dodgePoints;
    }
}
