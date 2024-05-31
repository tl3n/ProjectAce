using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //item data representation (base class ItemData for Artefact and Healing)
    [SerializeField] private ItemsData Item;
    //text instruction game object for instructions for the player
    [SerializeField] private GameObject PickUpText;
    //check for instruction done
    private bool isTriggerStayActivated = false;
    //inventory component
    private ItemManager ItemManager;
    //placeholder for Player Stats
    private Stats PlayerStats;

    //set text instructions invisible
    void Start()
    {
        //loading pick up key hint
        if (PickUpText == null)
        {
            PickUpText = Resources.Load<GameObject>("TextUI/Instructions");
        }

        if (PickUpText != null)
        {
            PickUpText.SetActive(false);
        }
        else
        {
            Debug.LogError("PickUpText not found or not assigned.");
        }

        //setting interface
        GameObject artefactDisplay = GameObject.Find("ArtefactDisplay");
        if (artefactDisplay != null)
        {
            ItemManager = artefactDisplay.GetComponent<ItemManager>();
        }
        else
        {
            Debug.LogError("ArtefactDisplay not found in the scene.");
        }

        if (ItemManager == null)
        {
            Debug.LogError("ItemManager component not found on ArtefactDisplay.");
        }
    }

    //check for E key pressed -- for destruction in OnTriggerStay
    void Update()
    {
        //isKeyPressed = Input.GetKeyDown(KeyCode.E);
        
        if (isTriggerStayActivated && PlayerStats != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && ItemManager.AddToInventory(Item) == true)
            {
                Debug.Log("Item added to inventory. Applying effect and destroying the item.");
                if (Item.effects == null)
                {
                    Debug.LogError($"Effects is not assigned in {Item.Name}");
                }
                else
                {
                    Item.Apply(PlayerStats);
                }
                Destroy(gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.E) && ItemManager.AddToInventory(Item) == false)
            {
                Debug.Log("Inventory full!");
            }
        }
    }

    //when enter -- show player the instructions for picking up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PickUpText != null)
            {
                PickUpText.SetActive(true);
            }
            PlayerStats = collision.GetComponent<Stats>();
            if (PlayerStats == null)
            {
                Debug.LogError("PlayerStats component not found on the player. Ensure the component is attached.");
            }
            Debug.Log(Item.name + " trigger box entered");
        }
    }

    //recreate visually picking up (destruction)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTriggerStayActivated = true;
        }
    }

    //switch off destruction
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PickUpText != null)
            {
                PickUpText.SetActive(false);
            }
            isTriggerStayActivated = false;
            Debug.Log(Item.name + " trigger box left");
        }
    }
}