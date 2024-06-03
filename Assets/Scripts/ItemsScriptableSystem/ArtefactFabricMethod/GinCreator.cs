using System.Collections.Generic;
using UnityEngine;

public class GinCreator : ArtefactFactory
{
    [SerializeField] private int[] _possibleItemIds;
    public int[] possibleItemIds
    {
        get { return _possibleItemIds; }
        set { _possibleItemIds = value; }
    }

    public override ItemsData CreateArtifact()
    {
        //var effect = ScriptableObject.CreateInstance<RandomItemsEffect>();
        effect.Initialize(possibleItemIds);

        ItemsData Gin = ScriptableObject.CreateInstance<ItemsData>();
        Gin.Name = "Lamp with Gin";
        Gin.Id = 3;
        Gin.ItemQuantity = 1;
        Gin.Description = "Gives one Item to choose among 3 random items";
        Gin.effects = effect;
        Gin.icon = Resources.Load<Sprite>("ItemPalette/Gin");
        Gin.prefab = Resources.Load<GameObject>("Prefabs/Gin");

        Debug.Log("Gin artifact created with RandomItemsEffect.");
        return Gin;
    }
}
