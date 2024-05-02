using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionTrigger : MonoBehaviour
{
    /// <summary>
    /// Difference of new camera position
    /// </summary>
    public Vector3 newCameraPosition;

    /// <summary>
    /// Difgerence of new player position
    /// </summary>
    public Vector3 newPlayerPosition;

    private CameraController cameraController;
    
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    /// <summary>
    /// Moves camera if player is going to next room 
    /// </summary>
    /// <param name="other">Object that collides with trigger</param>
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
