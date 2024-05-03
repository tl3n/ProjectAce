using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Healing item Item")]
public class HealingItem : ItemsData
{
    public override void Use()
    {
        Debug.Log("Hi");
    }
}
