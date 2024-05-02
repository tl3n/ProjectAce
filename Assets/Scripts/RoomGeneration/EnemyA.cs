using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyA : MonoBehaviour, Enemy
{
    // TODO: will be changed
    [SerializeField] private string enemyName = "EnemyA";

    public float angle = 0;

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