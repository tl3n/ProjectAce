using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of picking up an artefact when the player interacts with it.
/// </summary>
public class PickUpArtefact : MonoBehaviour
{
    //public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        //PickUpText.SetActive(false);
    }

    /// <summary>
    /// OnTriggerStay is called once per frame while the player stays in the trigger collider.
    /// </summary>
    /// <param name="OtherItem">The collider of the object colliding with this trigger.</param>
    private void OnTriggerStay(Collider OtherItem)
    {
        if (OtherItem.gameObject.tag == "Player")
        {
            // PickUpText.SetActive(true);
            Debug.Log("Trigger true");

            if (Input.GetKey(KeyCode.E))
            {
                //PickUpText.SetActive(false);
            }
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the player exits the trigger collider.
    /// </summary>
    /// <param name="other">The collider of the object that exited the trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        //PickUpText.SetActive(false);
        Debug.Log("Trigger false");
    }
}
