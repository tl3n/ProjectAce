using UnityEngine;

public class MelleEnemy : MonoBehaviour, Enemy
{
    // TODO: will be changed
    [SerializeField] private string enemyName = "MelleEnemy";

    public string EnemyName
    {
        get => enemyName;
        set => enemyName = value;
    }

    public float angle = 0;

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
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}