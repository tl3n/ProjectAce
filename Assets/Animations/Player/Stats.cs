using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//[CreateAssetMenu(menuName = "Object Stat")]
public class Stats : MonoBehaviour
{
    public event Action OnStatsChanged;

    private float _health = 100;
    public float health
    {
        get { return _health; }
        set
        {
            _health = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _speed = 1;
    public float speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _damage;
    public float damage
    {
        get { return _damage;  }
        set
        {
            _damage = value;
            OnStatsChanged?.Invoke();
        }
    }
    private float _luck;
    public float luck
    {
        get { return _luck; }
        set
        {
            _luck = value;
            OnStatsChanged?.Invoke();
        }
    }
}
