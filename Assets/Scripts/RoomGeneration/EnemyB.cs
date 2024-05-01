using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour, Enemy
{
    public GameObject enemyPrefab;

    [SerializeField] private string enemyName = "EnemyB";
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