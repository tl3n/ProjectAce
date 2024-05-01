using UnityEngine;

//public class EnemyBCreator : EnemiesCreator
//{
//    [SerializeField] private EnemyB enemyB;

//    public override Enemy Create(Transform room, Vector2 scenePosition, int xPos, int yPos)
//    {
//        Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);
//        GameObject newObject = Instantiate(enemyB.enemyPrefab, position, Quaternion.identity, room);

//        return enemyB;
//    }
//}


public class EnemyBCreator : EnemiesCreator
{
    [SerializeField] private EnemyB enemyPrefab;
    public override Enemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos)
    {
        Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);

        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(enemyPrefab.gameObject, position, Quaternion.identity, room);
        EnemyB newProduct = instance.GetComponent<EnemyB>();
        // each product contains its own logic
        newProduct.Initialize();
        return newProduct;
    }
}