using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementStrategy : MonoBehaviour
{
    //private EnemyMovement enemyMovement;
    protected Transform playerCollider;
    //protected Vector3 playerColliderPosition;

    private void Awake()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").transform
            .GetChild(1).transform;
        //enemyMovement = transform.GetComponent<EnemyMovement>();
        //UpdatePlayerColliderPosition();
    }
    
    public abstract void Move(EnemyMovement enemyMovement);

    /*public void UpdatePlayerColliderPosition()
    {
        playerColliderPosition = playerCollider.position;
    }*/
}
