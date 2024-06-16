using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Concrete artefact factory for creating the Black Cat artefact.
/// </summary>
public class BlackCatCreator : ArtefactFactory
{
    /// <summary>
    /// Creates and returns a new instance of the Black Cat artefact.
    /// </summary>
    /// <returns>The created Black Cat artefact instance.</returns>
    public override ItemsData CreateArtefact()
    {
        // Create healing effect
        var healingBoost = ScriptableObject.CreateInstance<HealingEffect>();
        healingBoost.healPoints = 10;

        // Create speed boost effect
        var speedBoost = ScriptableObject.CreateInstance<SpeedEffect>();
        speedBoost.speedPoints = 2f;

        // Create composite effect combining healing and speed boost
        var compositeEffect = ScriptableObject.CreateInstance<CompositeEffect>();
        compositeEffect.Initialize(new List<EffectsInterface> { healingBoost, speedBoost });

        // Create Black Cat artefact instance
        ItemsData BlackCat = ScriptableObject.CreateInstance<ItemsData>();
        BlackCat.Name = "Black Cat";
        BlackCat.Id = 3;
        BlackCat.ItemQuantity = 1;
        BlackCat.Description = "Your dear friend. Heals immediately and gives speed boost.";
        BlackCat.effects = compositeEffect;

        // Load icon and prefab resources
        BlackCat.icon = Resources.Load<Sprite>("ItemPalette/BlackCat");
        BlackCat.prefab = Resources.Load<GameObject>("Prefabs/BlackCat");

        return BlackCat;
    }
}
