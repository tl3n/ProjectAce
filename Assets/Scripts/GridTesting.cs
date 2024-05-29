using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    
    
    private void Start()
    {
        Pathfinding pathfinding = new Pathfinding(18, 5);
    }

    private void Update()
    {
       
    }

    private static Vector2 GetMouseWorldPosition()
    {
        Vector2 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        return vec;
    }

    private static Vector2 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector2 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}


