using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject InventoryVisuals;
    public bool menuActivated;

    public ItemSlot[] Slot;

    void Awake()
    {
        InventoryVisuals.SetActive(false);
    }

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
