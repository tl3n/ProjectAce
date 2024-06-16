using DungeonGeneration;
using System.Collections.Generic;
using UnityEngine;

namespace RoomGeneration
{
    public abstract class WeaponsFactory : MonoBehaviour
    {
        /// <summary>
        /// Grid of the generated rooms
        /// </summary>
        [SerializeField] protected Transform roomsGrid;

        /// <summary>
        /// Generation of weapons for each room from grid 
        /// </summary>
        /// <param name="roomsList">List of rooms of the generated dungeon</param>
        public void Generate(List<Room> roomsList) { }

        /// <summary>
        /// Generation of weapons for selected room
        /// </summary>
        /// <param name="roomType">Type of the room</param>
        /// <param name="roomNum">Number of the room in grid</param>
        protected void CreateWeapons(RoomType roomType, int roomNum) { }
    }


    public abstract class WeaponsCreator<T> : MonoBehaviour
    {
        public abstract T GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class MelleWeaponsCreator : WeaponsCreator<MelleWeapon>
    {
        public abstract override MelleWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class RangerWeaponsCreator : WeaponsCreator<RangerWeapon>
    {
        public abstract override RangerWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class BoomerangWeaponsCreator : WeaponsCreator<BoomerangWeapon>
    {
        public abstract override BoomerangWeapon GetWeapon(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }
}