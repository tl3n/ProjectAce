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

    //set text instructions invisible
    void Start()
    {
        PickUpText.SetActive(false);
        ItemManager = GameObject.Find("ArtefactDisplay").GetComponent<ItemManager>();

        //activate the artefact factory
        /*ArtefactFactory factory = new BlackCatCreator();
        ItemsData BlackCat = factory.CreateArtifact();
        ItemManager.AddToInventory(BlackCat);*/

    }

    //check for E key pressed -- for destruction in OnTriggerStay
    void Update()
    {
        //isKeyPressed = Input.GetKeyDown(KeyCode.E);

        if (isTriggerStayActivated)
        {
            if (Input.GetKeyDown(KeyCode.E) && ItemManager.AddToInventory(Item) == true)
            {
                Destroy(gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.E) && ItemManager.AddToInventory(Item) == false)
            {
                Debug.Log("Invertory full!");
            }
        }
    }

    //when enter -- show player the instructions for picking up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
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
        Debug.Log(Item.name + " trigger box left");
    }
}