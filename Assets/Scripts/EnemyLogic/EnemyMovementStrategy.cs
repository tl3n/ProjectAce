using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementStrategy : MonoBehaviour
{
    protected Vector3 playerShadowPosition;

    public EnemyMovementStrategy(Vector3 playerShadowPosition)
    {
        UpdatePlayerShadowPosition(playerShadowPosition);
    }
    
    public abstract void Move(EnemyMovement enemyMovement);

    public void UpdatePlayerShadowPosition(Vector3 playerShadowPosition)
    {
        this.playerShadowPosition = playerShadowPosition;
    }
}
