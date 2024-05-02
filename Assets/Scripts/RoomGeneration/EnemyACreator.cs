using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyACreator : EnemiesCreator
{
    /// <summary>
    /// Prefab of the enemyA
    /// </summary>
    [SerializeField] private EnemyA enemyPrefab;

    /// <summary>
    /// Creates a new enemyA
    /// </summary>
    /// <param name="room">Room in which enemy will be generated</param>
    /// <param name="scenePosition">Position of room</param>
    /// <param name="xPos">X-coordinate of the enemy</param>
    /// <param name="yPos">X-coordinate of the enemy</param>
    /// <returns>New enemyA</returns>
    public override Enemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos)
    {
        Vector2 position = new Vector2(scenePosition.x + xPos - 2, scenePosition.y + yPos - 2);

        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(enemyPrefab.gameObject, position, Quaternion.identity, room);
        EnemyA newEnemy = instance.GetComponent<EnemyA>();
        // each enemy contains its own logic
        newEnemy.Initialize();
        return newEnemy;
    }
}