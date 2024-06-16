using System.Collections.Generic;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

/// <summary>
/// Manages the UI interactions and inventory handling in the game.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Gets the singleton instance of the UIManager.
    /// </summary>
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// The selector game object used for UI selection.
    /// </summary>
    public GameObject Selector;

    /// <summary>
    /// Indicates if the selector is currently active.
    /// </summary>
    private bool isSelectorActive = false;

    /// <summary>
    /// Array of item slots in the UI.
    /// </summary>
    public ItemSlot[] Slot;

    /// <summary>
    /// Array of buttons associated with each item slot.
    /// </summary>
    public Button[] slotButton;

    /// <summary>
    /// Initializes the UIManager instance, ensuring singleton pattern.
    /// </summary>
    void Awake()
    {
        //singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        Selector.SetActive(false);
    }

    /// <summary>
    /// Handles the selection UI interaction.
    /// </summary>
    public void HandleSelection()
    {
        Time.timeScale = 0;
        Selector.SetActive(true);
        isSelectorActive = true;
    }

    /// <summary>
    /// Handles clicking on an item slot to apply its effect and add it to the inventory.
    /// </summary>
    /// <param name="item">The item being selected.</param>
    /// <param name="playerStats">The player's statistics.</param>
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

    /// <summary>
    /// Sets an item into an available slot in the UI.
    /// </summary>
    /// <param name="item">The item to add to the slot.</param>
    /// <param name="playerStats">The player's statistics.</param>
    /// <returns>True if the item was successfully added to a slot, false otherwise.</returns>
    public bool SetSlot(ItemsData item, Stats playerStats)
    {
        GameObject artefactDisplay = GameObject.Find("ArtefactDisplay");
        ItemManager itemManager = artefactDisplay.GetComponent<ItemManager>();

        for (int i = 0; i < Slot.Length; i++)
        {
            if (!Slot[i].full)
            {
                Slot[i].AddItem(item);
                SelectInterface slotClickCommand = new CommandInterface(item, playerStats, itemManager, this);
                slotButton[i].onClick.AddListener(() => slotClickCommand.Execute());
                return true;
            }
        }
        return false;
    }

}