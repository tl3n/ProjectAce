using UnityEngine;

public abstract class SummonerEnemy : MonoBehaviour, Enemy
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