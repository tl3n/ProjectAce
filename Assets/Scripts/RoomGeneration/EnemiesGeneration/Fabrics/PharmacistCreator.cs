using UnityEngine;

namespace RoomGeneration
{
    public class PharmacistCreator : SummonerEnemiesCreator
    {
        /// <summary>
        /// Prefab of the enemyB
        /// </summary>
        [SerializeField] private Pharmacist enemyPrefab;

        /// <summary>
        /// Creates a new enemyB
        /// </summary>
        /// <param name="room">Room in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the enemy</param>
        /// <param name="yPos">X-coordinate of the enemy</param>
        /// <returns>New enemyB</returns>
        public override SummonerEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);

            // create a Prefab instance and get the product component
            GameObject instance = Instantiate(enemyPrefab.gameObject, position, Quaternion.identity, room);
            SummonerEnemy newEnemy = instance.GetComponent<SummonerEnemy>();
            // each enemy contains its own logic
            newEnemy.Initialize();
            return newEnemy;
        }
    }
}