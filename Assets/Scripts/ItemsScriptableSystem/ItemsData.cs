using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//[CreateAssetMenu(menuName = "Item Default")]
public abstract class ItemsData : ScriptableObject
{
    [SerializeField] private string itemName = "Default Item Name";
    [SerializeField] private string itemDescription = "Default description";
    [SerializeField] private int quantity = 1;
    private int itemPrice;
    public Sprite icon;
    public GameObject prefab;
    //interface for the effects
    EffectsInterface effects;

    public void Apply(Stats playerStats)
    {
        effects.ApplyEffect(playerStats);
    }

    //setters
    public string Name => itemName;

    public string Description => itemDescription;

    public int ItemQuantity => quantity;

    public int Price => itemPrice;

    public abstract void Use();
}