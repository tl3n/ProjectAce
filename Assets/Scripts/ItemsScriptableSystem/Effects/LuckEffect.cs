using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckEffect : ScriptableObject, EffectsInterface
{
    public float luckPoints;

    public LuckEffect(float boost)
    {
        this.luckPoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.luck += luckPoints;
    }
}