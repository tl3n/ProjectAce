using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform shadowTransform;
    [SerializeField] private Transform playerShadowTransform;
    
    private const float speed = 20f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    private EnemyMovementStrategy movementStrategy;

    public void SetMovementStrategy(EnemyMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }
    
    private void Update()
    {
        if (movementStrategy != null)
        {
            Vector3 playerShadowPosition = playerShadowTransform.position;
            movementStrategy.UpdatePlayerShadowPosition(playerShadowPosition);
            movementStrategy.Move(this);
        }
    }

    public void HandleMovement()
    {
        
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(shadowTransform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - shadowTransform.position).normalized;
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }

    public Vector3 GetPosition()
    {
        return shadowTransform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
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
