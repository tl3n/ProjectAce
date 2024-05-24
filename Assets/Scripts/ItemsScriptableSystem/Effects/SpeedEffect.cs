using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpeedEffect : EffectsInterface
{
    private float speedPoints;

    public SpeedEffect(float boost)
    {
        this.speedPoints = boost;
    }

    public void ApplyEffect(Stats playerStats)
    {
        playerStats.speed += speedPoints;
    }
}
