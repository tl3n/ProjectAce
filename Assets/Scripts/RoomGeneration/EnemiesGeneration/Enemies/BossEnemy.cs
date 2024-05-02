using UnityEngine;

public class BossEnemy : MonoBehaviour, Enemy
{
    [SerializeField] private string enemyName = "BossEnemy";

    public string EnemyName
    {
        get => enemyName;
        set => enemyName = value;
    }

    /// <summary>
    /// hz cho napisat'
    /// </summary>
    private ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the enemy
    /// </summary>
    public void Initialize()
    {
        // any unique logic to this enemy
        gameObject.name = enemyName;
        //gameObject.tag = enemyTag;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}