using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Crutches : BoomerangWeapon
{
    private void Awake()
    {
        weaponName = "Crutches";
        force = 20;
        damage = 10;
        maxDistance = 5f;
    }
}