using System.Collections.Generic;
using UnityEngine;
using DungeonGeneration;

namespace RoomGeneration
{
    public class Level1WeaponsGenerator : WeaponsFactory
    {
        /// <summary>
        /// Fabric for melle weapon
        /// </summary>
        [SerializeField] protected MelleWeaponsCreator melleWeaponsCreator;

        /// <summary>
        /// Fabric for ranger weapon
        /// </summary>
        [SerializeField] protected RangerWeaponsCreator rangerWeaponsCreator;

        /// <summary>
        /// Fabric for boomerang weapon
        /// </summary>
        [SerializeField] protected BoomerangWeaponsCreator boomerangWeaponsCreator;

        /// <summary>
        /// List of the generated weapons
        /// </summary>
        private List<Weapon> weapons = new List<Weapon>();


        /// <summary>
        /// Generation of weapons for each room from grid 
        /// </summary>
        /// <param name="roomsList">List of rooms of the generated dungeon</param>
        public void Generate(List<Room> roomsList)
        {
            // for each room
            for (int i = 0; i < roomsList.Count; ++i)
            {
                CreateWeapons(roomsList[i].Type, i);
            }
        }

        /// <summary>
        /// Generation of weapons for selected room
        /// </summary>
        /// <param name="roomType">Type of the room</param>
        /// <param name="roomNum">Number of the room in grid</param>
        private void CreateWeapons(RoomType roomType, int roomNum)
        {
            // TODO: write here logic of generation

            // TODO: just testing, must be edited
            int difX = 3, difY = 0;

            Weapon weapon;
            weapon = boomerangWeaponsCreator.GetWeapon(roomsGrid.GetChild(roomNum), roomsGrid.GetChild(roomNum).position, difX, difY);
            weapons.Add(weapon);
        }
    }
}