using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SelectInterface
{
    void Execute();
}

public class CommandInterface : SelectInterface
{
    private ItemsData _item;
    private Stats _playerStats;
    private ItemManager _itemManager;
    private UIManager _uiManager;

    public CommandInterface(ItemsData item, Stats playerStats, ItemManager itemManager, UIManager uiManager)
    {
        _item = item;
        _playerStats = playerStats;
        _itemManager = itemManager;
        _uiManager = uiManager;
    }

    public void Execute()
    {
        Debug.Log(_item.Name + " " + _item.Id + " " + _item.Description + " added");
        _item.Apply(_playerStats);
        _itemManager.AddToInventory(_item);
        _uiManager.Selector.SetActive(false);
        Time.timeScale = 1;
    }
}