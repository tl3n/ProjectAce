using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemsData Item;
    public GameObject PickUpText;

    void Start()
    {
        PickUpText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            Debug.Log(Item.name + " trigger box entered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PickUpText.SetActive(false);
        Debug.Log(Item.name + " trigger box left");
    }
}
