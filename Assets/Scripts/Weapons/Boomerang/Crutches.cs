using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crutches : BoomerangWeapon
{
    public Crutches()
    {
        weaponName = "Crutches";
    }

    /// <summary>
    /// Initialization of the crutches
    /// </summary>
    public override void Initialize()
    {
        // any unique logic to this weapon
        gameObject.name = weaponName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}