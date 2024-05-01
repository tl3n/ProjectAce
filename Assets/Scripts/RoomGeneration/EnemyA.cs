using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, Enemy
{
    public GameObject enemyPrefab;

    [SerializeField] private string enemyName = "EnemyA";
    public string EnemyName
    {
        get => enemyName; 
        set => enemyName = value;
    }

    public bool SetActive(bool state)
    {
        enemyPrefab.SetActive(state);

        return state;
    }
}
