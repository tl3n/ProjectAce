using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Artefact Item")]
public class Artefact : ItemsData
{
    public override void Use()
    {
        Debug.Log("Hello");
    }
}



