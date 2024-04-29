using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemsData Item;
    
    //ui panel for the menu
    public GameObject InventoryVisuals;
    public bool menuActivated;

    private List<ItemSlot> Inventory;

    void Awake()
    {
        Inventory = new List<ItemSlot>();
        InventoryVisuals.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && menuActivated)
        {
            InventoryVisuals.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !menuActivated)
        {
            InventoryVisuals.SetActive(true);
            menuActivated = true;
        }
    }

    private void AddToInventory(ItemsData Item)
    {
        //addition logic
        
        
        Inventory.Add(setArtifactSlot());
    }
    private void RemoveFromInventory(ItemsData Item)
    {
        //removal logic
        Inventory.Remove(setArtifactSlot());
    }

    private ItemSlot setArtifactSlot()
    {
        ItemSlot slot = new ItemSlot();
        slot.slotName = Item.Name;
        slot.slotDescription = Item.Description;
        slot.slotItemSprite = Item.icon;
        return slot;
    }
}
