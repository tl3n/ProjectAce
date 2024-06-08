using System.Collections.Generic;
using UnityEngine;

public class GinCreator : ArtefactFactory
{
    private int[] _possibleItemIds = { 2, 3 };
    public int[] possibleItemIds
    {
        get { return _possibleItemIds; }
        set { _possibleItemIds = value; }
    }

    public override ItemsData CreateArtifact()
    {
        var effect = ScriptableObject.CreateInstance<RandomChoiceEffect>();
        effect.Initialize(_possibleItemIds);

        ItemsData Gin = ScriptableObject.CreateInstance<ItemsData>();
        Gin.Name = "Lamp with Gin";
        Gin.ItemQuantity = 1;
        Gin.Description = "Gives one Item to choose among 3 random items";
        Gin.effects = effect;
        Gin.icon = Resources.Load<Sprite>("ItemPalette/Gin");
        Gin.prefab = Resources.Load<GameObject>("Prefabs/Gin");

        return Gin;
    }
}
