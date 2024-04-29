using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour
{
    //  ITEM DATA

    /*[SerializeField]*/ private string SlotName = "Default Item Slot";
    public string slotName
    {
        get { return SlotName; }
        set { SlotName = value; }
    }

    /*[SerializeField]*/ private string SlotDescription = "None";
    public string slotDescription
    {
        get { return SlotDescription; }
        set { SlotDescription = value; }
    }

    private Sprite SlotItemSprite;
    public Sprite slotItemSprite
    {
        get { return SlotItemSprite; }
        set { SlotItemSprite = value; }
    }

    private bool isFull = false;
    public bool full
    {
        get { return isFull; }
        set { isFull = value; }
    }

    private int Quantity = 1;
    public int quantity
    {
        get { return Quantity; }
        set { Quantity = value; }
    }

    //  ITEM SLOT
    
    [SerializeField] private TMP_Text QuantityText;
    [SerializeField] private Image SlotImage;

    public void AddItem(ItemsData Item)
    {
        this.SlotName = Item.Name;
        this.SlotDescription = Item.Description;
        this.SlotItemSprite = Item.icon;
        this.Quantity = Item.ItemQuantity;
        this.isFull = true;

        QuantityText.text = Item.ItemQuantity.ToString();
        QuantityText.enabled = true;

        SlotImage.sprite = Item.icon;
    }
}
