using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cards : RangerWeapon
{
    public Cards()
    {
        weaponName = "Cards";
        force = 20;
        damage = 1;
    }

    /// <summary>
    /// Initialization of the cards
    /// </summary>
    // public override void Initialize()
    // {
    //     // any unique logic to this weapon
    //     gameObject.name = weaponName;
    //     particleSystem = GetComponentInChildren<ParticleSystem>();
    //     particleSystem?.Stop();
    //     particleSystem?.Play();
    // }

    
}