using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private string SlotName = "Default Item Slot";
    public string slotName
    {
        get { return SlotName; }
        set { SlotName = value; }
    }

    [SerializeField] private string SlotDescription = "None";
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

    private int SlotItemStack = 0;
    public int slotItemStack
    {
        get { return SlotItemStack; }
        set { SlotItemStack = value; }
    }
}
