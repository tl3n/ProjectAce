using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversumCreator : ArtefactFactory
{
    public override ItemsData CreateArtefact()
    {

        var hpBoost = ScriptableObject.CreateInstance<MaxHPAmplifyEffect>();
        hpBoost.hpAmplifyPoints = 30f;

        var speedBoost = ScriptableObject.CreateInstance<SpeedEffect>();
        speedBoost.speedPoints = 2f;
        
        var damageBoost = ScriptableObject.CreateInstance<DamageEffect>();
        damageBoost.damagePoints = 15f;
        
        var luckBoost = ScriptableObject.CreateInstance<LuckEffect>();
        luckBoost.luckPoints = 15f;

        var compositeEffect = ScriptableObject.CreateInstance<CompositeEffect>();
        compositeEffect.Initialize(new List<EffectsInterface> { hpBoost, speedBoost, damageBoost, luckBoost });

        //add icon and quantity
        ItemsData Universum = ScriptableObject.CreateInstance<ItemsData>();
        Universum.Name = "Universum";
        Universum.Id = 4;
        Universum.ItemQuantity = 1;
        Universum.Description = "Fraction of universe. Gives boosts for all stats.";
        Universum.effects = compositeEffect;

        Universum.icon = Resources.Load<Sprite>("ItemPalette/universum");
        Universum.prefab = Resources.Load<GameObject>("Prefabs/Universum");

        return Universum;
    }
}