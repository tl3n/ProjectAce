using UnityEngine;
using UnityEngine.UIElements;

public class Doctor : MelleEnemy
{
    public Doctor()
    {
        enemyName = "Doctor";
        angle = 0;
    }

    /// <summary>
    /// Initialization of the doctor
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