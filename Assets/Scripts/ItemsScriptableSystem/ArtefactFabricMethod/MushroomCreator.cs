using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCreator : ArtefactFactory
{
    public override ItemsData CreateArtifact()
    {
        var multipliers = new float[] { 2.0f, 1.0f, 4.0f, 0.5f };
        var damageBoost = ScriptableObject.CreateInstance<RandomDamageEffect>();

        /*var compositeEffect = ScriptableObject.CreateInstance<CompositeEffect>();
        compositeEffect.Initialize(new List<EffectsInterface> { damageBoost });*/

        damageBoost.Initialize(multipliers);


        ItemsData Mushroom = ScriptableObject.CreateInstance<ItemsData>();
        Mushroom.Name = "Mushroom";
        Mushroom.ItemQuantity = 1;
        Mushroom.Description = "Gives RandomBoost for the damage";
        Mushroom.effects = damageBoost;
        Mushroom.icon = Resources.Load<Sprite>("ItemPalette/Mushroom");
        Mushroom.prefab = Resources.Load<GameObject>("Prefabs/Mushroom");

        return Mushroom;
    }
}