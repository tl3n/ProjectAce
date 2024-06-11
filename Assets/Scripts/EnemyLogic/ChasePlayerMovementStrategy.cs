using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerMovementStrategy : EnemyMovementStrategy
{
    public override void Move(EnemyMovement enemyMovement)
    {
        enemyMovement.SetTargetPosition(playerCollider.position);
        enemyMovement.HandleMovement();
    }
}
