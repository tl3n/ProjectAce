using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionTrigger : MonoBehaviour
{
    public Vector3 newCameraPosition;
    public Vector3 newPlayerPosition;

    private CameraController cameraController;
    
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.minPosition += newCameraPosition;
            cameraController.maxPosition += newCameraPosition;

            other.transform.position += newPlayerPosition;
        }
    }
}
