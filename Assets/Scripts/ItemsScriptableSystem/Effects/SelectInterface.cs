using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for defining a selection command.
/// </summary>
public interface SelectInterface
{
    /// <summary>
    /// Executes the selection command.
    /// </summary>
    void Execute();
}

/// <summary>
/// Command that implements the SelectInterface to handle item selection.
/// </summary>
public class CommandInterface : SelectInterface
{
    private ItemsData _item;
    private Stats _playerStats;
    private ItemManager _itemManager;
    private UIManager _uiManager;

    /// <summary>
    /// Initializes a new instance of the CommandInterface class with the specified item, player stats, item manager, and UI manager.
    /// </summary>
    /// <param name="item">The item to be handled by the command.</param>
    /// <param name="playerStats">The player's stats to apply the item's effects.</param>
    /// <param name="itemManager">The manager responsible for managing items.</param>
    /// <param name="uiManager">The UI manager responsible for UI operations.</param>
    public CommandInterface(ItemsData item, Stats playerStats, ItemManager itemManager, UIManager uiManager)
    {
        _item = item;
        _playerStats = playerStats;
        _itemManager = itemManager;
        _uiManager = uiManager;
    }

    /// <summary>
    /// Executes the command to add the item to the inventory, apply its effects, and update UI.
    /// </summary>
    public void Execute()
    {
        Debug.Log(_item.Name + " " + _item.Id + " " + _item.Description + " added");
        _item.Apply(_playerStats);
        _itemManager.AddToInventory(_item);
        _uiManager.Selector.SetActive(false);
        Time.timeScale = 1;
    }
}