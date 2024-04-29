using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //item data representation (base class ItemData for Artefact and Healing)
    public ItemsData Item;
    //text instruction game object for instructions for the player
    [SerializeField] public GameObject PickUpText;
    //check for instruction done
    private bool isKeyPressed = false;

    //set text instructions invisible
    void Start()
    {
        PickUpText.SetActive(false);
    }

    //check for E key pressed -- for destruction in OnTriggerStay
    void Update()
    {
       isKeyPressed = Input.GetKeyDown(KeyCode.E);
    }

    //when enter -- show player the instructions for picking up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            Debug.Log(Item.name + " trigger box entered");
           
        }
    }

    //recreate visually picking up (destruction)
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Stay");

        //check for instruction done
        if (isKeyPressed)
        {
            Debug.Log(" 'E' pressed success");

            //if item prefab exist
            if (Item.prefab != null)
            {
                //destroy the prefab instance from the scene
                OnDestroy();
                Debug.Log("Item destroyed");
            }
            //report error -- unable to remove not existing objects
            else
            {
                Debug.Log("Error: Item has been already destroyed");
            }
        }
    }

    //switch off destruction
    private void OnTriggerExit2D(Collider2D collision)
    {
        PickUpText.SetActive(false);
        Debug.Log(Item.name + " trigger box left");
    }

    private void OnDestroy()
    {
        //turn of text instruction + destroy prefab
        PickUpText.SetActive(false);
        Destroy(gameObject);
    }
}
