using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversumCreator : ArtefactFactory
{
    public override ItemsData CreateArtefact()
    {

        var healingBoost = ScriptableObject.CreateInstance<HealingEffect>();
        healingBoost.healPoints = 30f;

        var speedBoost = ScriptableObject.CreateInstance<SpeedEffect>();
        speedBoost.speedPoints = 2f;
        
        var damageBoost = ScriptableObject.CreateInstance<DamageEffect>();
        damageBoost.damagePoints = 15f;
        
        var luckBoost = ScriptableObject.CreateInstance<LuckEffect>();
        luckBoost.luckPoints = 15f;

        var compositeEffect = ScriptableObject.CreateInstance<CompositeEffect>();
        compositeEffect.Initialize(new List<EffectsInterface> { healingBoost, speedBoost, damageBoost, luckBoost });

        //add icon and quantity
        ItemsData Universum = ScriptableObject.CreateInstance<ItemsData>();
        Universum.Name = "Universum";
        Universum.Id = 4;
        Universum.ItemQuantity = 1;
        Universum.Description = "Gives boosts for all stats.";
        Universum.effects = compositeEffect;

        Universum.icon = Resources.Load<Sprite>("ItemPalette/universum test");
        Universum.prefab = Resources.Load<GameObject>("Prefabs/BlackCat");

        return Universum;
    }
}