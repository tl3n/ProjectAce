using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Concrete artefact factory for creating the Mushroom artefact.
/// </summary>
public class MushroomCreator : ArtefactFactory
{
    /// <summary>
    /// Creates and returns a new instance of the Mushroom artefact.
    /// </summary>
    /// <returns>The created Mushroom artefact instance.</returns>
    public override ItemsData CreateArtefact()
    {
        // Initialize array of damage multipliers for random damage effect
        var multipliers = new float[] { 2.0f, 1.0f, 4.0f, 0.5f };
        var damageBoost = ScriptableObject.CreateInstance<RandomDamageEffect>();
        damageBoost.Initialize(multipliers);

        // Create Mushroom artefact instance
        ItemsData Mushroom = ScriptableObject.CreateInstance<ItemsData>();
        Mushroom.Name = "Mushroom";
        Mushroom.ItemQuantity = 1;
        Mushroom.Id = 2;
        Mushroom.Description = "We're high on shrooms! Your hits deal random damage.";
        Mushroom.effects = damageBoost;
        Mushroom.icon = Resources.Load<Sprite>("ItemPalette/Mushroom");
        Mushroom.prefab = Resources.Load<GameObject>("Prefabs/Mushroom");

        return Mushroom;
    }
}
