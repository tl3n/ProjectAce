using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpArtefact : MonoBehaviour
{
    //public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        //PickUpText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider OtherItem)
    {
        if(OtherItem.gameObject.tag == "Player")
        {
           // PickUpText.SetActive(true);
            Debug.Log("Trigger true");

            if (Input.GetKey(KeyCode.E))
            {
                //PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //PickUpText.SetActive(false);
        Debug.Log("Trigger false");
    }
}
