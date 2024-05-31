using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Knife : MelleWeapon
{
    public Knife()
    {
        weaponName = "Knife";
    }

    /// <summary>
    /// Initialization of the knife
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