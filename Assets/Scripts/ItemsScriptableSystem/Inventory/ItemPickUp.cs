using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //item data representation (base class ItemData for Artefact and Healing)
    public ItemsData Item;
    //text instruction game object for instructions for the player
    [SerializeField] public GameObject PickUpText;
    //check for instruction done
    private bool isTriggerStayActivated = false;
    //inventory component
    private ItemManager ItemManager;
    //placeholder for Player Stats
    private Stats PlayerStats;

    //set text instructions invisible
    void Start()
    {
        PickUpText.SetActive(false);
        ItemManager = GameObject.Find("ArtefactDisplay").GetComponent<ItemManager>();
    }

    //check for E key pressed -- for destruction in OnTriggerStay
    void Update()
    {
        //isKeyPressed = Input.GetKeyDown(KeyCode.E);
        
        if (isTriggerStayActivated && PlayerStats != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && ItemManager.AddToInventory(Item) == true)
            {
                 Item.Apply(PlayerStats);
;                Destroy(gameObject);
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
            PickUpText.SetActive(true);
            PlayerStats = collision.GetComponent<Stats>();
            Debug.Log(Item.name + " trigger box entered");
        }
    }

    //recreate visually picking up (destruction)
    private void OnTriggerStay2D(Collider2D collision)
    {
        isTriggerStayActivated = true;
    }

    //switch off destruction
    private void OnTriggerExit2D(Collider2D collision)
    {
        PickUpText.SetActive(false);
        isTriggerStayActivated = false;
        Debug.Log(Item.name + " trigger box left");
    }
}