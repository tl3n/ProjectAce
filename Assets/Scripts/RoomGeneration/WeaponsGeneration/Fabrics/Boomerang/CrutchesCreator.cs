using UnityEngine;

namespace RoomGeneration
{
    public class CrutchesCreator : BoomerangWeaponsCreator
    {
        /// <summary>
        /// Prefab of the crutches
        /// </summary>
        [SerializeField] private Crutches weaponPrefab;

        /// <summary>
        /// Creates new crutches
        /// </summary>
        /// <param name="room">Room in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the weapon</param>
        /// <param name="yPos">X-coordinate of the weapon</param>
        /// <returns>New crutches</returns>
        public override BoomerangWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);

            // create a Prefab instance and get the crutches component
            GameObject instance = Instantiate(weaponPrefab.gameObject, position, Quaternion.identity, room);
            Crutches newWeapon = instance.GetComponent<Crutches>();
            // each crutches contains its own logic
            newWeapon.Initialize();
            return newWeapon;
        }
    }
}