using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float transitionSpeed;

    private Vector3 targetPosition;
    private Vector3 newPosition;

    public Vector3 minPosition, maxPosition;

    // Update is called after all other updates
    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            targetPosition = player.position;

            Vector3 cameraBoundaryPosition = new Vector3(
                Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y),
                Mathf.Clamp(targetPosition.z, minPosition.z, maxPosition.z));

            newPosition = Vector3.Lerp(transform.position, cameraBoundaryPosition, transitionSpeed);
            transform.position = newPosition;
        }
    }
}
