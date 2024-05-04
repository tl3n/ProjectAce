using UnityEngine;

namespace RoomGeneration
{
    public class SprayCreator : RangerWeaponsCreator
    {
        /// <summary>
        /// Prefab of the spray
        /// </summary>
        [SerializeField] private Spray weaponPrefab;

        /// <summary>
        /// Creates a new spray
        /// </summary>
        /// <param name="room">Room in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the weapon</param>
        /// <param name="yPos">X-coordinate of the weapon</param>
        /// <returns>New spray</returns>
        public override RangerWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);

            // create a Prefab instance and get the spray component
            GameObject instance = Instantiate(weaponPrefab.gameObject, position, Quaternion.identity, room);
            Spray newWeapon = instance.GetComponent<Spray>();
            // each spray contains its own logic
            newWeapon.Initialize();
            return newWeapon;
        }
    }
}