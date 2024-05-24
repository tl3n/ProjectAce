using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//[CreateAssetMenu(menuName = "Item Default")]
public class ItemsData : ScriptableObject
{
    [SerializeField] private string itemName = "Default Item Name";
    [SerializeField] private string itemDescription = "Default description";
    [SerializeField] private int quantity = 1;
    private int itemPrice;
    public Sprite icon;
    public GameObject prefab;
    //interface for the effects -- strategy pattern
    public EffectsInterface effects;

    public void Apply(Stats playerStats)
    {
        effects.ApplyEffect(playerStats);
    }

    //setters
    public string Name
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string Description
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public int ItemQuantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public int Price
    {
        get { return itemPrice; }
        set { itemPrice = value; }
    }

    //public abstract void Use();
}
