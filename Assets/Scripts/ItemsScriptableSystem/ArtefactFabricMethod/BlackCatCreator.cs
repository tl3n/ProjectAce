using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatCreator : ArtefactFactory
{
    public override ItemsData CreateArtefact()
    {

        var healingBoost = ScriptableObject.CreateInstance<HealingEffect>();
        healingBoost.healPoints = 10;

        var speedBoost = ScriptableObject.CreateInstance<SpeedEffect>();
        speedBoost.speedPoints = 1.5f;

        var compositeEffect = ScriptableObject.CreateInstance<CompositeEffect>();
        compositeEffect.Initialize(new List<EffectsInterface> { healingBoost, speedBoost });

        //add icon and quantity
        ItemsData BlackCat = ScriptableObject.CreateInstance<ItemsData>();
        BlackCat.Name = "Black Cat";
        BlackCat.Id = 3;
        BlackCat.ItemQuantity = 1;
        BlackCat.Description = "Heals immediately and gives speed boost";
        BlackCat.effects = compositeEffect;

        BlackCat.icon = Resources.Load<Sprite>("ItemPalette/BlackCat");
        BlackCat.prefab = Resources.Load<GameObject>("Prefabs/BlackCat");

        return BlackCat;
    }
}
