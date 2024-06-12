using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MelleWeapon : Weapon
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        base.Start();
        
        gameObject.tag = "MelleWeapon";
    }
}