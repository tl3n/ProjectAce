using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IGridComponent
{
    /// <summary>
    /// Name of the enemy
    /// </summary>
    [SerializeField] protected string enemyName = "Enemy";

    /// <summary>
    /// Layer of the enemy
    /// </summary>
    [SerializeField] protected float layer;

    public string EnemyName { get; set; }

    /// <summary>
    /// Each enemy has its own particle system
    /// </summary>
    protected ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public abstract void Initialize();

    void Update()
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = Mathf.RoundToInt(transform.localPosition.y * -10f + layer);
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