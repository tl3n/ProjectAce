using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemyACreator : EnemiesCreator
//{
//    [SerializeField] private EnemyA enemyA;    

//    public override Enemy Create(Transform room, Vector2 scenePosition, int xPos, int yPos) 
//    {
//        Vector2 position = new Vector2(scenePosition.x + xPos - 2, scenePosition.y + yPos - 2);
//        //GameObject newObject = Instantiate(enemyA.enemyPrefab, position, Quaternion.identity, room);

//        GameObject instance = Instantiate(enemyA.enemyPrefab,position, Quaternion.identity, room);
//        EnemyA newProduct = instance.GetComponent<EnemyA>();
//        // each product contains its own logic
//        newProduct.Initialize();

//        enemyA.enemyObject = instance;

//        return enemyA;
//    }
//}

public class EnemyACreator : EnemiesCreator
{
    [SerializeField] private EnemyA enemyPrefab;
    public override Enemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos)
    {
        Vector2 position = new Vector2(scenePosition.x + xPos - 2, scenePosition.y + yPos - 2);

        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(enemyPrefab.gameObject, position, Quaternion.identity, room);
        EnemyA newProduct = instance.GetComponent<EnemyA>();
        // each product contains its own logic
        newProduct.Initialize();
        return newProduct;
    }
}