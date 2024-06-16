using UnityEngine;

/// <summary>
/// ScriptableObject representing a generic item with properties such as name, description, quantity, icon, prefab, and effects.
/// </summary>
[CreateAssetMenu(menuName = "Item Default")]
public class ItemsData : ScriptableObject
{
    [SerializeField] private string itemName = "Default Item Name";
    [SerializeField] private string itemDescription = "Default description";
    [SerializeField] private int quantity = 1;
    private int itemPrice;
    [SerializeField] private int itemId = -1;
    public Sprite icon;
    public GameObject prefab;
    public EffectsInterface effects;

    /// <summary>
    /// Applies the effects of the item to the specified player's statistics.
    /// </summary>
    /// <param name="playerStats">The player's statistics to apply the effects to.</param>
    public void Apply(Stats playerStats)
    {
        if (effects != null)
        {
            effects.ApplyEffect(playerStats);
        }
        else
        {
            Debug.LogError($"Effects is not assigned in {itemName}");
        }
    }

    /// <summary>
    /// Initializes the item with the specified name, description, and effects interface.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="description">The description of the item.</param>
    /// <param name="effect">The effects interface to be assigned to the item.</param>
    public void Initialize(string name, string description, EffectsInterface effect)
    {
        this.itemName = name;
        this.itemDescription = description;
        this.effects = effect;
    }

    // Getters and setters

    /// <summary>
    /// The name of the item.
    /// </summary>
    public string Name
    {
        get { return itemName; }
        set { itemName = value; }
    }

    /// <summary>
    /// The unique ID of the item.
    /// </summary>
    public int Id
    {
        get { return itemId; }
        set { itemId = value; }
    }

    /// <summary>
    /// The description of the item.
    /// </summary>
    public string Description
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    /// <summary>
    /// The quantity of the item.
    /// </summary>
    public int ItemQuantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    /// <summary>
    /// The price of the item.
    /// </summary>
    public int Price
    {
        get { return itemPrice; }
        set { itemPrice = value; }
    }
}
