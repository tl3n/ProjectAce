using DungeonGeneration;
using System.Collections.Generic;
using UnityEngine;

namespace RoomGeneration
{
    public abstract class EnemiesFactory : MonoBehaviour
    {
        /// <summary>
        /// Grid of the generated rooms
        /// </summary>
        [SerializeField] protected Transform roomsGrid;

        /// <summary>
        /// Generation of enemies for each room from grid 
        /// </summary>
        /// <param name="roomsList">List of rooms of the generated dungeon</param>
        public void Generate(List<Room> roomsList) { }

        /// <summary>
        /// Generation of enemies for selected room
        /// </summary>
        /// <param name="roomType">Type of the room</param>
        /// <param name="roomNum">Number of the room in grid</param>
        protected void CreateEnemies(RoomType roomType, int roomNum) { }
    }


    public abstract class EnemiesCreator<T> : MonoBehaviour
    {
        public abstract T GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class MelleEnemiesCreator : EnemiesCreator<MelleEnemy>
    {
        public abstract override MelleEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class RangerEnemiesCreator : EnemiesCreator<RangerEnemy>
    {
        public abstract override RangerEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class SummonerEnemiesCreator : EnemiesCreator<SummonerEnemy>
    {
        public abstract override SummonerEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class BossEnemiesCreator : EnemiesCreator<BossEnemy>
    {
        public abstract override BossEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }
}