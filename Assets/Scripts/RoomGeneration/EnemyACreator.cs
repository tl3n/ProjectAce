using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyACreator : EnemiesCreator
{
    [SerializeField] private EnemyA enemyA;    

    public override Enemy Create(Transform room, Vector2 scenePosition, int xPos, int yPos) 
    {
        Vector2 position = new Vector2(scenePosition.x + xPos - 2, scenePosition.y + yPos - 2);
        GameObject newObject = Instantiate(enemyA.enemyPrefab, position, Quaternion.identity, room);

        return enemyA;
    }
}
