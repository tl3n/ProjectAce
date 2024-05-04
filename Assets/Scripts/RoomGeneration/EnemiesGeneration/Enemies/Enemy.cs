using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    /// <summary>
    /// Name of the enemy
    /// </summary>
    [SerializeField] protected string enemyName;

    public string EnemyName { get; set; }

    /// <summary>
    /// Each enemy has its own particle system
    /// </summary>
    protected ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public abstract void Initialize();
}