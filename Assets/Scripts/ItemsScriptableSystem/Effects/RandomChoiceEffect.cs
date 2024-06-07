using System.Collections;
using System.Collections.Generic;
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

        //we need only 2 items
        while (selectedItems.Count < 2)
        {
            //select some random id
            int selectedId = randomIds[Random.Range(0, randomIds.Length)];
            //checking for the sake of not picking same ids by chance
            
            if (!usedIds.Contains(selectedId))
            {
                
                ItemsData randomItem = PossibleItemManager.Instance.GetItemById(selectedId);
                
                if (randomItem != null)
                {
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
    }
}
