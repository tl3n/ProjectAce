using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//public class EnemyA : MonoBehaviour, Enemy
//{
//    public GameObject enemyPrefab;

//    public GameObject enemyObject;

//    public float angle = 0;

//    //public int Angle 
//    //{ 
//    //    get => angle; 
//    //    set => angle = value; 
//    //}

//    [SerializeField] private string enemyName = "EnemyA";
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

//    private ParticleSystem particleSystem;

//    public void Initialize()
//    {
//        // any unique logic to this product
//        gameObject.name = enemyName;
//        particleSystem = GetComponentInChildren<ParticleSystem>();
//        particleSystem?.Stop();
//        particleSystem?.Play();
//    }
//}


public class EnemyA : MonoBehaviour, Enemy
{
    [SerializeField] private string enemyName = "EnemyA";
    //[SerializeField] private GameObject enemyPrefab;
    public float angle = 0;
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