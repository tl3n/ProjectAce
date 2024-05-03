using UnityEngine;
using UnityEngine.UIElements;

public abstract class MelleEnemy : MonoBehaviour, Enemy
{
    [SerializeField] protected string enemyName;

    public string EnemyName
    {
        get => enemyName;
        set => enemyName = value;
    }

    public float angle;

    /// <summary>
    /// hz cho napisat'
    /// </summary>
    protected ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public void Initialize() { }
}