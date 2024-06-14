using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* \brief A movement strategy for enemies that chases the player.
*/
public class ChasePlayerMovementStrategy : EnemyMovementStrategy
{
    /**
    * \brief Moves the enemy towards the player's position.
    * \param enemyMovement The EnemyMovement component that handles the enemy's movement.
    */
    public override void Move(EnemyMovement enemyMovement)
    {
        enemyMovement.SetTargetPosition(playerCollider.position);
        enemyMovement.HandleMovement();
    }
}
