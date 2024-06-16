using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

/// <summary>
/// Manages possible items, including loading and retrieving items by ID.
/// </summary>
public class PossibleItemManager
{
    /// <summary>
    /// Dictionary to store item data with item ID as the key.
    /// </summary>
    private Dictionary<int, ItemsData> itemsDictionary;

    /// <summary>
    /// Initializes a new instance of the <see cref="PossibleItemManager"/> class and initializes the items dictionary.
    /// </summary>
    public PossibleItemManager()
    {
        InitializeItemsDictionary();
    }

    /// <summary>
    /// Initializes the items dictionary by loading item data from resources.
    /// </summary>
    private void InitializeItemsDictionary()
    {
        Debug.Log("Dictionary initialization");
        itemsDictionary = new Dictionary<int, ItemsData>();

        // Loading scriptable objects from the folder
        ItemsData[] itemsArray = Resources.LoadAll<ItemsData>("ItemObjects/");

        // Checking loaded array
        if (itemsArray == null || itemsArray.Length == 0)
        {
            Debug.LogError("No items found in the 'ItemObjects' folder or folder is missing.");
            return;
        }

        foreach (var item in itemsArray)
        {
            if (item == null)
            {
                Debug.LogWarning("Found a null item in the 'ItemObjects' folder.");
                continue;
            }

            if (!itemsDictionary.ContainsKey(item.Id) && item.Id > 0)
            {
                Debug.Log($"Adding item with ID: {item.Id} and Name: {item.Name}");
                itemsDictionary.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"Duplicate item ID found: {item.Id}. Item Name: {item.Name}");
            }
        }

        Debug.Log($"Total items added to the dictionary: {itemsDictionary.Count}");
    }

    /// <summary>
    /// Retrieves an item by its ID from the items dictionary.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The item data if found; otherwise, null.</returns>
    public ItemsData GetItemById(int id)
    {
        if (itemsDictionary.TryGetValue(id, out var item))
        {
            return item;
        }
        else
        {
            Debug.LogError($"Item with ID {id} not found.");
            return null;
        }
    }
}
