using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float movementSpeed;
    
    public int attackDamage;
    public float attackRange;
    public float attackCooldown;
    public bool lineOfSight;
    
    public string enemyName;

    public Pathfinding pathfinding;
    
    [SerializeField] private EnemyMovementStrategy movementStrategy;
    private EnemyMovement movement;
    
    
    private void Start()
    {
        //pathfinding = Find
        movement = GetComponent<EnemyMovement>();
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public EnemyMovementStrategy GetMovementStrategy()
    {
        return movementStrategy;
    }
    
}
