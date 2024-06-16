using UnityEngine;

namespace RoomGeneration
{
    public class DoctorCreator : MelleEnemiesCreator
    {
        /// <summary>
        /// Prefab of the doctor
        /// </summary>
        [SerializeField] private Doctor enemyPrefab;

        /// <summary>
        /// Creates a new doctor
        /// </summary>
        /// <param name="room">Room in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the enemy</param>
        /// <param name="yPos">X-coordinate of the enemy</param>
        /// <returns>New doctor</returns>
        public override MelleEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos); // TODO: delete -2 !!!!!

            // create a Prefab instance and get the doctor component
            GameObject instance = Instantiate(enemyPrefab.gameObject, position, Quaternion.identity, room);
            Doctor newEnemy = instance.GetComponent<Doctor>();
            // each enemy contains its own logic
            //newEnemy.Initialize(); TODO
            return newEnemy;
        }
    }
}