using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemsData Item;
    
    //ui panel for the menu
    public GameObject InventoryVisuals;
    public bool menuActivated;

   // private List<ItemSlot> Inventory;
    //choose between array and list
    public ItemSlot[] Slot; 

    void Awake()
    {
        //Inventory = new List<ItemSlot>();
        InventoryVisuals.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryVisuals.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryVisuals.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddToInventory(ItemsData Item)
    {
        //addition logic
        //Debug.Log(" >>> OBTAINED:" + Item.Name + " " + Item.Description + " " + Item.Price);
        
        for (int i = 0; i < Slot.Length; i++) 
        {
            if (Slot[i].full == false)
            {
                Slot[i].AddItem(Item);
                return;
            }
        }

        /*Inventory.Add(setArtifactSlot());*/
    }
    private void RemoveFromInventory(ItemsData Item)
    {
        //removal logic
        //Inventory.Remove(setArtifactSlot());
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
