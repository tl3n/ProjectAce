using UnityEngine;

public class Pharmacist : SummonerEnemy
{
    public Pharmacist()
    {
        enemyName = "Pharmacist";
    }

    /// <summary>
    /// Initialization of the pharmacist
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