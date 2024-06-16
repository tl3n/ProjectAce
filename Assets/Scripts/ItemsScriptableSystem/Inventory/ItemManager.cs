using UnityEngine;

/// <summary>
/// Manages the inventory system, including adding and removing items.
/// </summary>
public class ItemManager : MonoBehaviour
{
    /// <summary>
    /// The visual representation of the inventory.
    /// </summary>
    public GameObject InventoryVisuals;

    /// <summary>
    /// Indicates if the inventory menu is currently activated.
    /// </summary>
    public bool menuActivated;

    /// <summary>
    /// Array of item slots in the inventory.
    /// </summary>
    public ItemSlot[] Slot;

    /// <summary>
    /// Initializes the ItemManager and deactivates the inventory visuals.
    /// </summary>
    void Awake()
    {
        InventoryVisuals.SetActive(false);
    }

    /// <summary>
    /// Updates the inventory menu state based on user input.
    /// </summary>
    void Update()
    {
        if (menuActivated && !Input.GetKeyDown(KeyCode.Q))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (menuActivated)
            {
                Time.timeScale = 1;
                InventoryVisuals.SetActive(false);
                menuActivated = false;
            }
            else
            {
                Time.timeScale = 0;
                InventoryVisuals.SetActive(true);
                menuActivated = true;
            }
        }

        if (!menuActivated)
        {
            for (int i = 0; i < Slot.Length; i++)
            {
                Slot[i].HoverPanel.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Adds an item to the inventory if there is an available slot.
    /// </summary>
    /// <param name="Item">The item to add to the inventory.</param>
    /// <returns>True if the item was successfully added, false otherwise.</returns>
    public bool AddToInventory(ItemsData Item)
    {
        for (int i = 0; i < Slot.Length; i++)
        {
            if (!Slot[i].full)
            {
                Slot[i].AddItem(Item);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Removes an item from its slot in the inventory.
    /// </summary>
    /// <param name="Item">The item to remove from the inventory.</param>
    public void RemoveItemFromSlot(ItemsData Item)
    {
        for (int i = 0; i < Slot.Length; i++)
        {
            if (Slot[i].slotName == Item.Name && Slot[i].full)
            {
                Slot[i].RemoveItem();
            }
        }
    }
}
