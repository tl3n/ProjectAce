using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMaskCreator : ArtefactFactory
{
    public override ItemsData CreateArtefact()
    {

        
        var dodgeBoost = ScriptableObject.CreateInstance<DodgeEffect>();
        dodgeBoost.dodgePoints = 20f;

        //add icon and quantity
        ItemsData HappyMask = ScriptableObject.CreateInstance<ItemsData>();
        HappyMask.Name = "Hapy Theater Mask";
        HappyMask.Id = 5;
        HappyMask.ItemQuantity = 1;
        HappyMask.Description = "You're a trickster! Gives dodge chance.";
        HappyMask.effects = dodgeBoost;

        HappyMask.icon = Resources.Load<Sprite>("ItemPalette/HappyMask");
        HappyMask.prefab = Resources.Load<GameObject>("Prefabs/HappyMask");

        return HappyMask;
    }
}
