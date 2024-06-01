using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crutches : BoomerangWeapon
{
    public Crutches()
    {
        weaponName = "Crutches";
        force = 20;
        damage = 1;
        maxDistance = 5f;
    }
}