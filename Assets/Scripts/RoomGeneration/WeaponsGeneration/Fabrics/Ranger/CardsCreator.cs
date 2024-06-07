using UnityEngine;

namespace RoomGeneration
{
    public class CardsCreator : RangerWeaponsCreator
    {
        /// <summary>
        /// Prefab of the cards
        /// </summary>
        [SerializeField] private Cards weaponPrefab;

        /// <summary>
        /// Creates new cards
        /// </summary>
        /// <param name="room">GridRoom in which enemy will be generated</param>
        /// <param name="scenePosition">Position of room</param>
        /// <param name="xPos">X-coordinate of the weapon</param>
        /// <param name="yPos">X-coordinate of the weapon</param>
        /// <returns>New spray</returns>
        public override RangerWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos)
        {
            Vector2 position = new Vector2(scenePosition.x + xPos, scenePosition.y + yPos);

            // create a Prefab instance and get the spray component
            GameObject instance = Instantiate(weaponPrefab.gameObject, position, Quaternion.identity, room);
            Cards newWeapon = instance.GetComponent<Cards>();
            // each spray contains its own logic
            newWeapon.Initialize();
            return newWeapon;
        }
    }
}