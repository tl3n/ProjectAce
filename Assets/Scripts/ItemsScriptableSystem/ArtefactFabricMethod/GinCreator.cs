using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Concrete artefact factory for creating the Gin artefact.
/// </summary>
public class GinCreator : ArtefactFactory
{
    private int[] _possibleItemIds = { 2, 3 };

    /// <summary>
    /// Array of possible item IDs that can be selected when using the Gin artefact.
    /// </summary>
    public int[] possibleItemIds
    {
        get { return _possibleItemIds; }
        set { _possibleItemIds = value; }
    }

    /// <summary>
    /// Creates and returns a new instance of the Gin artefact.
    /// </summary>
    /// <returns>The created Gin artefact instance.</returns>
    public override ItemsData CreateArtefact()
    {
        // Create random choice effect with possible item IDs
        var effect = ScriptableObject.CreateInstance<RandomChoiceEffect>();
        effect.Initialize(_possibleItemIds);

        // Create Gin artefact instance
        ItemsData Gin = ScriptableObject.CreateInstance<ItemsData>();
        Gin.Name = "Lamp with Gin";
        Gin.ItemQuantity = 1;
        Gin.Description = "Three wishes! You can only choose one, though.";
        Gin.effects = effect;
        Gin.icon = Resources.Load<Sprite>("ItemPalette/Gin");
        Gin.prefab = Resources.Load<GameObject>("Prefabs/Gin");

        return Gin;
    }
}
