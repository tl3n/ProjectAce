using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Represents the stats and attributes of a player or game object.
/// </summary>
public class Stats : MonoBehaviour
{
    public event Action OnStatsChanged;

    private float _currentHealth = 100;
    /// <summary>
    /// Current health of the object.
    /// </summary>
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
    /// <summary>
    /// Maximum health capacity of the object.
    /// </summary>
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
    /// <summary>
    /// Movement speed of the object.
    /// </summary>
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
    /// <summary>
    /// Chance of dodging attacks.
    /// </summary>
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
    /// <summary>
    /// Base damage inflicted by the object.
    /// </summary>
    public float defaultDamage
    {
        get { return _defaultDamage; }
        set
        {
            _defaultDamage = value;
            OnStatsChanged?.Invoke();
        }
    }

    private float _upgradedDamage;
    /// <summary>
    /// Modified damage after applying damage multipliers.
    /// </summary>
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
    /// <summary>
    /// Luck factor affecting various game events.
    /// </summary>
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

    /// <summary>
    /// Applies a damage multiplier to the default damage.
    /// </summary>
    /// <param name="multiplier">Multiplier to apply to the default damage.</param>
    public void AddDamageModifier(float multiplier)
    {
        _upgradedDamage = _defaultDamage * multiplier;
    }
}
