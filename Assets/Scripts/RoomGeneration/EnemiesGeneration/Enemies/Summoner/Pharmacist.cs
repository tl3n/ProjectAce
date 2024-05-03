using UnityEngine;

public class Pharmacist : SummonerEnemy
{
    [SerializeField] private string enemyName = "Pharmacist";

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
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}