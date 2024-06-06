using UnityEngine;

[CreateAssetMenu(menuName = "Item Default")]
public class ItemsData : ScriptableObject
{
    [SerializeField] private string itemName = "Default Item Name";
    [SerializeField] private string itemDescription = "Default description";
    [SerializeField] private int quantity = 1;
    private int itemPrice;
    private int itemId;
    public Sprite icon;
    public GameObject prefab;
    public EffectsInterface effects;

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

    public void Initialize(string name, string description, EffectsInterface effect)
    {
        this.itemName = name;
        this.itemDescription = description;
        this.effects = effect;
    }

    // setters
    public string Name
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public int Id 
    {
        get { return itemId; }
        set { itemId = value; }
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
}
