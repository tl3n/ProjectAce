using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    public string EnemyName { get; set; }
    public bool SetActive(bool state);
}