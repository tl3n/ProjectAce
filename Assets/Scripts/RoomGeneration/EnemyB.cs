using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyB : MonoBehaviour, Enemy
{
    [SerializeField] private string enemyName = "EnemyB";
    

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