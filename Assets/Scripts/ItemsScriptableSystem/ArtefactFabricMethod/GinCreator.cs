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

    public override ItemsData CreateArtefact()
    {
        var effect = ScriptableObject.CreateInstance<RandomChoiceEffect>();
        effect.Initialize(_possibleItemIds);

        ItemsData Gin = ScriptableObject.CreateInstance<ItemsData>();
        Gin.Name = "Lamp with Gin";
        Gin.Id = 1;
        Gin.ItemQuantity = 1;
        Gin.Description = "Three wishes! You can only choose one, though.";
        Gin.effects = effect;
        Gin.icon = Resources.Load<Sprite>("ItemPalette/Gin");
        Gin.prefab = Resources.Load<GameObject>("Prefabs/Gin");

        return Gin;
    }
}
