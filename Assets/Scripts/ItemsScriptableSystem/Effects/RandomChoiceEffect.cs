using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomChoiceEffect : ScriptableObject, EffectsInterface
{
    private int[] randomIds;

    public void Initialize(int[] itemIdRange)
    {
        //duplicates parsed ids
        this.randomIds = itemIdRange;
        Debug.Log("Random IDs initialized: " + string.Join(", ", randomIds));
    }

    public void ApplyEffect(Stats playerStats)
    {
        //not existing or empty array check
        if (randomIds == null || randomIds.Length == 0)
        {
            Debug.LogError("Possible item IDs array is null or empty. Ensure it is initialized before calling ApplyEffect.");
            return;
        }
        SelectItems(playerStats);
    }

    private void SelectItems(Stats playerStats)
    {
        //selected items list initialization
        List<ItemsData> selectedItems = new List<ItemsData>();
        //list of already used ids initialization
        List<int> usedIds = new List<int>();
        //summoning all artefacts dictionary
        PossibleItemManager PossibleItemsManager = new PossibleItemManager();

        //we need only 2 items
        while (selectedItems.Count < 2)
        {
            //select some random id
            int selectedId = randomIds[Random.Range(0, randomIds.Length)];
            Debug.Log("Selected Id: " + selectedId);
            //checking for the sake of not picking same ids by chance
            
            if (!usedIds.Contains(selectedId))
            {         
                ItemsData randomItem = PossibleItemsManager.GetItemById(selectedId);    

                if (randomItem != null)
                {
                    Debug.Log(randomItem.Name);
                    selectedItems.Add(randomItem);
                    usedIds.Add(selectedId);
                }
                else
                {
                    Debug.LogError($"Item with ID {selectedId} is null.");
                }
            }
        }

        //adapt ui -- UIManager

        GameObject SelectionMenu = GameObject.Find("SelectionDisplay");
        UIManager Selector = SelectionMenu.GetComponent<UIManager>();

        foreach (var item in selectedItems)
        {
            Debug.Log(item.Name);
            Selector.SetSlot(item, playerStats);
            Selector.HandleSelection();
        }        
    }
}
