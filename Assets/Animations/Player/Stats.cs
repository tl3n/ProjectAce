using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//[CreateAssetMenu(menuName = "Object Stat")]
public class Stats : MonoBehaviour
{
    public event Action OnStatsChanged;

    private float _currentHealth = 100;
    public float currentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            OnStatsChanged?.Invoke();
        }
    }
    
    private float _maxHealth = 100;
    public float maxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _speed = 7f;
    public float speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            OnStatsChanged?.Invoke();
        }
    }
    
    private float _dodgeChance = 0f;
    public float dodgeChance
    {
        get { return _dodgeChance; }
        set
        {
            _dodgeChance = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _defaultDamage = 10;
    public float defaultDamage
    {
        get { return _defaultDamage;  }
        set
        {
            _defaultDamage = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _upgradedDamage;
    public float upgradedDamage
    {
        get { return _upgradedDamage; }
        set
        {
            _upgradedDamage = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _luck = 0;
    public float luck
    {
        get { return _luck; }
        set
        {
            _luck = value;
            OnStatsChanged?.Invoke();
        }
    }

    private void Start()
    {
        _upgradedDamage = _defaultDamage;
    }
    public void AddDamageModifier(float multiplier)
    {
        _upgradedDamage = _defaultDamage * multiplier;
    }
}