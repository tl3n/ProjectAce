using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* \brief An abstract class representing an enemy movement strategy.
*/
public abstract class EnemyMovementStrategy : MonoBehaviour
{
    /// <summary>
    /// The Transform component of the player's collider.
    /// </summary>
    protected Transform playerCollider;
    
    /**
    * \brief Awake is called when the script instance is being loaded.
    *
    * Finds the player GameObject by tag and gets the Transform component of its second child GameObject.
    */
    private void Awake()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerShadow");
    }
    
    /**
    * \brief Abstract method for moving the enemy.
    * \param enemyMovement The EnemyMovement component that handles the enemy's movement.
    */
    public abstract void Move(EnemyMovement enemyMovement);
}
