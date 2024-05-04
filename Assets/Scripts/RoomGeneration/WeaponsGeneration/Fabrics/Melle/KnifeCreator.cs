using UnityEngine;

namespace RoomGeneration
{
    public class KnifeCreator : MelleWeaponsCreator
    {
        /// <summary>
        /// Prefab of the knife
        /// </summary>
        [SerializeField] private Knife weaponPrefab;

        /// <summary>
        /// Creates a new knife
        /// </summary>
        /// <param name="room">Room in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the weapon</param>
        /// <param name="yPos">X-coordinate of the weapon</param>
        /// <returns>New knife</returns>
        public override MelleWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos); 

            // create a Prefab instance and get the knife component
            GameObject instance = Instantiate(weaponPrefab.gameObject, position, Quaternion.identity, room);
            Knife newWeapon = instance.GetComponent<Knife>();
            // each knife contains its own logic
            newWeapon.Initialize();
            return newWeapon;
        }
    }
}