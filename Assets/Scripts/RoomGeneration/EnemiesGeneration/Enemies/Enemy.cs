using UnityEngine;

public interface Enemy
{
    public string EnemyName { get; set; }
    public void Initialize();
}