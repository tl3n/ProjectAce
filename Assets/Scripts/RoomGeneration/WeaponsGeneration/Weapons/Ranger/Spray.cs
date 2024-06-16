using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spray : RangerWeapon
{
    public Spray()
    {
        weaponName = "Spray";
    }

    /// <summary>
    /// Initialization of the spray
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