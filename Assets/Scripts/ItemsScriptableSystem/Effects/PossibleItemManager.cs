using System.Collections.Generic;
using UnityEngine;

public class PossibleItemManager : MonoBehaviour
{
    public static PossibleItemManager Instance;

    private Dictionary<int, ItemsData> itemsDictionary;

    //SINGLETON
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeItemsDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeItemsDictionary()
    {
        itemsDictionary = new Dictionary<int, ItemsData>();

        //loading scriptable objects from the folder
        ItemsData[] itemsArray = Resources.LoadAll<ItemsData>("ItemObjects");

        //checking loaded array
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

            if (!itemsDictionary.ContainsKey(item.Id))
            {
                Debug.Log($"Adding item with ID: {item.Id} and Name: {item.Name}");
                itemsDictionary.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"Duplicate item ID found: {item.Id}. Item Name: {item.Name}");
            }
        }

        //Debug.Log($"Total items added to the dictionary: {itemsDictionary.Count}");
    }

    //used in the PossibleItemsManager to get by random id
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
