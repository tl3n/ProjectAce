using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

/// <summary>
/// Manages the individual item slots in the inventory UI, including displaying item information and handling pointer events.
/// </summary>
public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// The text component used to display the item description when hovering over the slot.
    /// </summary>
    public TMP_Text HoverPanel;

    /// <summary>
    /// The name of the item slot.
    /// </summary>
    private string SlotName = "Default Item Slot";
    public string slotName
    {
        get { return SlotName; }
        set { SlotName = value; }
    }

    /// <summary>
    /// The description of the item slot.
    /// </summary>
    private string SlotDescription = "None";
    public string slotDescription
    {
        get { return SlotDescription; }
        set { SlotDescription = value; }
    }

    /// <summary>
    /// The sprite representing the item in the slot.
    /// </summary>
    private Sprite SlotItemSprite;
    public Sprite slotItemSprite
    {
        get { return SlotItemSprite; }
        set { SlotItemSprite = value; }
    }

    /// <summary>
    /// Indicates if the slot is currently full.
    /// </summary>
    private bool isFull = false;
    public bool full
    {
        get { return isFull; }
        set { isFull = value; }
    }

    /// <summary>
    /// The quantity of items in the slot.
    /// </summary>
    private int Quantity = 1;
    public int quantity
    {
        get { return Quantity; }
        set { Quantity = value; }
    }

    /// <summary>
    /// The text component used to display the quantity of items in the slot.
    /// </summary>
    [SerializeField] private TMP_Text QuantityText;

    /// <summary>
    /// The image component used to display the item icon in the slot.
    /// </summary>
    [SerializeField] private Image SlotImage;

    /// <summary>
    /// Adds an item to the slot and updates the UI accordingly.
    /// </summary>
    /// <param name="Item">The item data to add to the slot.</param>
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
        SlotImage.enabled = true;
    }

    /// <summary>
    /// Removes the item from the slot and updates the UI accordingly.
    /// </summary>
    public void RemoveItem()
    {
        this.SlotName = "Default Item Slot";
        this.SlotDescription = "None";
        this.SlotItemSprite = null;
        this.Quantity = 1;
        this.isFull = false;

        QuantityText.text = "";
        QuantityText.enabled = false;

        SlotImage.sprite = null;
        SlotImage.enabled = false;
    }

    /// <summary>
    /// Displays the item description when the pointer enters the slot.
    /// </summary>
    /// <param name="eventData">The pointer event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel.text = this.slotDescription;
        HoverPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the item description when the pointer exits the slot.
    /// </summary>
    /// <param name="eventData">The pointer event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        HoverPanel.gameObject.SetActive(false);
    }
}
