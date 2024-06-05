using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridTesting : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyPathfinding;

    private MovementGrid grid;
    private Pathfinding pathfinding;
    
    private void Start()
    {
        pathfinding = new Pathfinding();
        grid = pathfinding.GetGrid();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(9, 2, x, y);
            if (path != null)
            {
                Debug.ClearDeveloperConsole();
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector2(path[i].x, path[i].y) * 5f + Vector2.one * 2.5f, new Vector2(path[i+1].x, path[i+1].y) * 5f + Vector2.one * 2.5f, Color.green, 5);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            
            PathNode node = pathfinding.GetNode(x, y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
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


