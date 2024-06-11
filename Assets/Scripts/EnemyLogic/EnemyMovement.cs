using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyMovementStrategy movementStrategy;

    private Transform enemyCollider;
    private Vector3 playerColliderPosition;
    
    private const float speed = 20f; // TODO: initialize it using EnemyController?
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    
    private const float avoidanceRadius = .5f;
    private Vector3 targetPosition;

    private void Start()
    {
        enemyCollider = transform.GetChild(1).transform;
    }
    private void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(this);
        }
    }
    
    public void SetMovementStrategy(EnemyMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }
    
    public void HandleMovement()
    {
        Vector3 enemyColliderPosition = FindEnemyColliderPosition();
        Vector3 moveDir = (targetPosition - enemyColliderPosition).normalized;
        float distance = Vector3.Distance(FindEnemyColliderPosition(), targetPosition);
        
        if (distance > 1.5f)
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }
        else
        {
            currentPathIndex++;
            if (pathVectorList != null && currentPathIndex >= pathVectorList.Count)
            {
                StopMoving();
            }
        }
    }

    private bool HasLineOfSight(Vector3 targetPosition)
    {
        Vector3 enemyColliderPosition = FindEnemyColliderPosition();
        Vector3 direction = (targetPosition - enemyColliderPosition);
        float distance = direction.magnitude;
        LayerMask unwalkableMask = LayerMask.NameToLayer("Unwalkable");

        RaycastHit2D hit = Physics2D.Raycast(enemyColliderPosition, direction, distance, 1 << unwalkableMask);
        Debug.Log(hit.collider == null);
        return hit.collider == null;
    }
    public void SetTargetPosition(Vector3 targetPosition)
    {
        if (!HasLineOfSight(targetPosition))
        {
            currentPathIndex = 0;
            pathVectorList = Pathfinding.Instance.FindPath(FindEnemyColliderPosition(), targetPosition);

            if (pathVectorList != null && pathVectorList.Count > 1)
            {
                pathVectorList.RemoveAt(0);
            }
            
            this.targetPosition = pathVectorList[currentPathIndex];
        }
        else
        {
            //Debug.Log("has line of sight");
            this.targetPosition = targetPosition;
            pathVectorList = null;
        }
    }
    
    private void StopMoving()
    {
        targetPosition = FindEnemyColliderPosition();
        pathVectorList = null;
    }

    public Vector3 FindEnemyColliderPosition()
    {
        return enemyCollider.position;
    }

    
}
