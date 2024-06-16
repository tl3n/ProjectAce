using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Represents an effect that randomly selects items from a predefined range of item IDs and applies them to the player.
/// </summary>
public class RandomChoiceEffect : ScriptableObject, EffectsInterface
{
    /// <summary>
    /// Array of possible item IDs to choose from.
    /// </summary>
    private int[] randomIds;

    /// <summary>
    /// Initializes the effect with a range of item IDs.
    /// </summary>
    /// <param name="itemIdRange">Array of possible item IDs to choose from.</param>
    public void Initialize(int[] itemIdRange)
    {
        // Duplicates parsed IDs
        this.randomIds = itemIdRange;
        Debug.Log("Random IDs initialized: " + string.Join(", ", randomIds));
    }

    /// <summary>
    /// Applies the random choice effect to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the effect will be applied.</param>
    public void ApplyEffect(Stats playerStats)
    {
        // Check if the array of possible item IDs is not null or empty
        if (randomIds == null || randomIds.Length == 0)
        {
            Debug.LogError("Possible item IDs array is null or empty. Ensure it is initialized before calling ApplyEffect.");
            return;
        }
        SelectItems(playerStats);
    }

    /// <summary>
    /// Selects random items from the possible item IDs and applies them to the player's stats.
    /// </summary>
    /// <param name="playerStats">The player's statistics to which the selected items will be applied.</param>
    private void SelectItems(Stats playerStats)
    {
        // Initialize list for selected items
        List<ItemsData> selectedItems = new List<ItemsData>();
        // Initialize list for already used IDs
        List<int> usedIds = new List<int>();
        // Create a new instance of PossibleItemManager to access the items dictionary
        PossibleItemManager PossibleItemsManager = new PossibleItemManager();

        // Select 2 items
        while (selectedItems.Count < 2)
        {
            // Select a random ID from the array
            int selectedId = randomIds[Random.Range(0, randomIds.Length)];
            Debug.Log("Selected Id: " + selectedId);

            // Check if the selected ID has already been used
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

        // Load and instantiate the selection menu UI
        GameObject SelectionMenuPrefab = Resources.Load<GameObject>("InteractiveElements/SelectionDisplay");
        GameObject SelectionMenu = Instantiate(SelectionMenuPrefab);
        UIManager Selector = SelectionMenu.GetComponent<UIManager>();

        // Set selected items in the UI and handle selection
        foreach (var item in selectedItems)
        {
            Debug.Log(item.Name);
            Selector.SetSlot(item, playerStats);
            Selector.HandleSelection();
        }
    }
}
