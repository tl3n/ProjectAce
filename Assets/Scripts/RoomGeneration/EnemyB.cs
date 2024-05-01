using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//public class EnemyB : MonoBehaviour, Enemy
//{
//    public GameObject enemyPrefab;

//    [SerializeField] private string enemyName = "EnemyB";
//    public string EnemyName
//    {
//        get => enemyName; 
//        set => enemyName = value;
//    }

//    public bool SetActive(bool state)
//    {
//        enemyPrefab.SetActive(state);

//        return state;
//    }
//}

public class EnemyB : MonoBehaviour, Enemy
{
    [SerializeField] private string enemyName = "EnemyB";
    //[SerializeField] private GameObject enemyPrefab;
    public string EnemyName
    {
        get => enemyName; set => enemyName
   = value;
    }
    private ParticleSystem particleSystem;
    public void Initialize()
    {
        // any unique logic to this product
        gameObject.name = enemyName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}