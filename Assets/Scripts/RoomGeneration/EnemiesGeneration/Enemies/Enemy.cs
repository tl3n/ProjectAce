using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IGridComponent
{
    /// <summary>
    /// Name of the enemy
    /// </summary>
    [SerializeField] protected string enemyName = "Enemy";
    [SerializeField] protected const int maxHealth = 100;
    [SerializeField] protected float movementSpeed = 20f;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackCooldown;
    
    
    protected int health;
    protected bool lineOfSight;
    protected Pathfinding pathfinding;
    protected EnemyMovementStrategy movementStrategy;
    protected EnemyMovement movement;
    protected Transform playerTransform;

    protected float lastAttackTime;
    public bool isWalking;
    public bool isAttacking;
    
    /// <summary>
    /// Each enemy has its own particle system
    /// </summary>
    protected ParticleSystem particleSystem;
    
    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public abstract void Initialize();
    
    protected Pathfinding InitializePathfinding()
    {
        this.pathfinding = GetComponent<Pathfinding>();
        int i = transform.parent.GetSiblingIndex();
        MovementGrid grid = GameObject.FindWithTag("MovementGrid").transform.GetChild(i).GetComponent<MovementGrid>();
        pathfinding.grid = grid;
        return pathfinding;
    }
    
    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public EnemyMovementStrategy GetMovementStrategy()
    {
        return movementStrategy;
    }
    
    /// <summary>
    /// Enemy is leaf, so return exception
    /// </summary>
    /// <param name="component">Grid component</param>
    /// <exception cref="NotImplementedException">Method is not implemented</exception>
    public void Add(IGridComponent component)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Enemy is leaf, so return exception
    /// </summary>
    /// <param name="component">Grid component</param>
    /// <exception cref="NotImplementedException">Method is not implemented</exception>
    public void Remove(IGridComponent component)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns name of the enemy
    /// </summary>
    /// <returns>enemyName</returns>
    public string GetName()
    {
        return enemyName;
    }

    /// <summary>
    /// Check if enemy is composite
    /// </summary>
    /// <returns>False</returns>
    public bool IsComposite()
    {
        return false;
    }

    /// <summary>
    /// Change state of the enemy
    /// </summary>
    /// <param name="state">State to which it will be changed</param>
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }
}