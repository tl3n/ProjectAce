using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerMovementStrategy : EnemyMovementStrategy
{
    public ChasePlayerMovementStrategy(Vector3 playerShadowPosition) : base(playerShadowPosition) {}
    
    public override void Move(EnemyMovement enemyMovement)
    {
        enemyMovement.SetTargetPosition(playerShadowPosition);
        enemyMovement.HandleMovement();
    }
}
