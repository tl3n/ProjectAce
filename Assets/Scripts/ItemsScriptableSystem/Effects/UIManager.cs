using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    public GameObject Selector;
    private bool isSelectorActive = false;
    public ItemSlot[] Slot;
    public Button[] slotButton;

    void Awake()
    {
        Selector.SetActive(false);
    }


    public void Update()
    {
        /*while (isSelectorActive == true)
        {
            if(Input.GetKeyDown(KeyCode.Q) == true)
            {
                return;
            }
        }*/    
    }

    public void HandleSelection()
    {
        Time.timeScale = 0;
        Selector.SetActive(true);
        isSelectorActive = true;
    }

    void HandleSlotClick(ItemsData item, Stats playerStats)
    {
        Debug.Log(item.Name + " " + item.Id + " " + item.Description + " added");

        GameObject artefactDisplay = GameObject.Find("ArtefactDisplay");
        ItemManager ItemManager = artefactDisplay.GetComponent<ItemManager>();

        item.Apply(playerStats);
        ItemManager.AddToInventory(item);
        Selector.SetActive(false);
        Time.timeScale = 1;
    }

    public bool SetSlot(ItemsData Item, Stats playerStats)
    {
        for (int i = 0; i < Slot.Length; i++)
        {
            if (!Slot[i].full)
            {
                Slot[i].AddItem(Item);
                slotButton[i].onClick.AddListener(() => HandleSlotClick(Item, playerStats));
                return true;
            }
        }
        return false;
    }

}