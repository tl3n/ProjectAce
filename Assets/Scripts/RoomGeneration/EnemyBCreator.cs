using UnityEngine;

public class EnemyBCreator : EnemiesCreator
{
    [SerializeField] private EnemyB enemyB;

    public override Enemy Create(Transform room, Vector2 scenePosition, int xPos, int yPos)
    {
        Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);
        GameObject newObject = Instantiate(enemyB.enemyPrefab, position, Quaternion.identity, room);

        return enemyB;
    }
}
