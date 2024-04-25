using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Create New Item" , menuName = "Item Default")]
public abstract class ItemsData : ScriptableObject
{
    [SerializeField] private string itemName = "Default Item Name";
    [SerializeField] private string itemDescription = "Default description";
    private int itemPrice;
    public Sprite icon;
    public GameObject prefab;

    //setters
    public string Name => itemName;

    public string Description => itemDescription;

    public int Price => itemPrice;

    public abstract void Use();
}

[CreateAssetMenu(menuName = "Artefact Item")]
public class Artefact : ItemsData
{
    public override void Use()
    {
        // Artefacts logic
    }
}

[CreateAssetMenu(menuName = "Healing item Item")]
public class HealingItem : ItemsData
{
    public override void Use()
    {
        // Healing items logic
    }
}

