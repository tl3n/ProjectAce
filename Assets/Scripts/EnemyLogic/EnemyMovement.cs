using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* \brief A class for handling enemy movement.
*/
public class EnemyMovement : MonoBehaviour
{
    
    private EnemyController enemyController;
    private EnemyMovementStrategy movementStrategy;
    
    /// <summary>The Transform component of the enemy's collider.</summary>
    private Transform colliderTransform;
    
    /// <summary>The target position for the enemy to move towards.</summary>
    private Vector3 targetPosition;
    
    /// <summary>The movement speed of the enemy.</summary>
    private float movementSpeed;
    
    /// <summary>The list of vectors representing the path for the enemy to follow.</summary>
    private List<Vector3> pathVectorList;
    
    /// <summary>The current index in the path vector list.</summary>
    private int currentPathIndex;
    
    /**
    * \brief Start is called before the first frame update.
    *
    * Initializes the enemy controller, collider transform, movement speed, and movement strategy.
    */
    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        colliderTransform = transform.Find("EnemyShadow");
        movementSpeed = enemyController.GetMovementSpeed();
        movementStrategy = enemyController.GetMovementStrategy();
    }
    /**
   * \brief Update is called once per frame.
   *
   * Calls the Move method of the movement strategy, if it exists.
   */
    private void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(this);
        }
    }
    
    /**
    * \brief Handles the enemy's movement towards the target position.
    */
    public void HandleMovement()
    {
        Vector3 enemyColliderPosition = FindEnemyColliderPosition();
        Vector3 moveDir = (targetPosition - enemyColliderPosition).normalized;
        float distance = Vector3.Distance(FindEnemyColliderPosition(), targetPosition);
        
        if (distance > 1.5f)
        {
            transform.position += moveDir * movementSpeed * Time.deltaTime;
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
    
    /**
    * \brief Sets the target position for the enemy to move towards.
    * \param targetPosition The target position.
    */
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
            this.targetPosition = targetPosition;
            pathVectorList = null;
        }
    }
    
    /**
     * \brief Stops the enemy's movement.
     */
    private void StopMoving()
    {
        targetPosition = FindEnemyColliderPosition();
        pathVectorList = null;
    }
    
    /**
    * \brief Checks if the enemy has a line of sight to the target position.
    * \param targetPosition The target position.
    * \return True if there is a line of sight, false otherwise.
    */
    private bool HasLineOfSight(Vector3 targetPosition)
    {
        Vector3 enemyColliderPosition = FindEnemyColliderPosition();
        Vector3 direction = (targetPosition - enemyColliderPosition);
        float distance = direction.magnitude;
        LayerMask unwalkableMask = LayerMask.NameToLayer("Unwalkable");

        RaycastHit2D hit = Physics2D.Raycast(enemyColliderPosition, direction, distance, 1 << unwalkableMask);
        return hit.collider == null;
    }
    
    /**
     * \brief Finds the position of the enemy's collider.
     * \return The position of the enemy's collider.
     */
    private Vector3 FindEnemyColliderPosition()
    {
        return colliderTransform.position;
    }

    
}
