using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // health
    public int health;
    public int maxHealth;
    
    // attack
    public int attackDamage;
    public float attackRange;
    public float attackCooldown;
    public bool lineOfSight;
    
    // identification
    public string enemyName;
    
    private EnemyMovement enemyMovement;

    private void Start()
    {
        new Pathfinding();
        enemyMovement = GetComponent<EnemyMovement>();
    }
}
