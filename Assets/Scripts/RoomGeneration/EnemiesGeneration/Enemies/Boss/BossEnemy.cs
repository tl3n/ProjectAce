using UnityEngine;

public abstract class BossEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] protected string enemyName;

    public string EnemyName
    {
        get => enemyName;
        set => enemyName = value;
    }

    /// <summary>
    /// hz cho napisat'
    /// </summary>
    protected ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public void Initialize() { }
}