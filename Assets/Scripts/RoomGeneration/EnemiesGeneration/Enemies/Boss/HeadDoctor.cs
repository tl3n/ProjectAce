using UnityEngine;

public class HeadDoctor : BossEnemy
{
    public HeadDoctor()
    {
        enemyName = "HeadDoctor";
    }

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