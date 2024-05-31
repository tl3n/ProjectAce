using UnityEngine;

public class Syringe : RangerEnemy
{
    public Syringe()
    {
        enemyName = "Syringe";
    }

    /// <summary>
    /// Initialization of the syringe
    /// </summary>
    public override void Initialize()
    {
        // any unique logic to this enemy
        gameObject.name = enemyName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}