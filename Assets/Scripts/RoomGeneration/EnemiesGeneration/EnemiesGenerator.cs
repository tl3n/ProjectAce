using System.Collections.Generic;
using UnityEngine;
using DungeonGeneration;

namespace RoomGeneration
{
    public class EnemiesGenerator : MonoBehaviour
    {
        /// <summary>
        /// Fabric for melle enemy
        /// </summary>
        [SerializeField] private DoctorCreator doctorCreator;

        /// <summary>
        /// Fabric for ranger enemy
        /// </summary>
        [SerializeField] private SyringeCreator syringeCreator;

        /// <summary>
        /// Fabric for summoner enemy
        /// </summary>
        [SerializeField] private PharmacistCreator pharmacistCreator;

        /// <summary>
        /// Fabric for boss enemy
        /// </summary>
        [SerializeField] private HeadDoctorCreator headDoctorCreator;

        /// <summary>
        /// Grid of the generated rooms
        /// </summary>
        public Transform roomsGrid;

        /// <summary>
        /// List of the generated enemies
        /// </summary>
        private List<Enemy> enemies = new List<Enemy>();

        /// <summary>
        /// Generation of enemies for each room from grid 
        /// </summary>
        /// <param name="roomsList">List of rooms of the generated dungeon</param>
        public void Generate(List<Room> roomsList)
        {
            // for each room
            for(int i = 0; i < roomsList.Count; ++i)
            {
                //Debug.Log(i);
                CreateEnemies(roomsList[i].Type, i);
            }

            //CreateEnemies(roomsList[roomsList.Count - 1].Type, roomsList.Count);
        }

        /// <summary>
        /// Generation of enemies for selected room
        /// </summary>
        /// <param name="roomType">Type of the room</param>
        /// <param name="roomNum">Number of the room in grid</param>
        private void CreateEnemies(RoomType roomType, int roomNum) 
        {
            // TODO: just testing, must be edited
            int difX = 0, difY = 0;

            if (roomType == RoomType.Start)
                difX = difY = 2;
            else
                difX = difY = 0;

            Enemy enemy;

            enemy = doctorCreator.GetEnemy(roomsGrid.GetChild(roomNum), roomsGrid.GetChild(roomNum).position, difX, difY);

            Debug.Log(enemy);

            //if (enemy != null) enemies.Add(enemy);

            enemies.Add(enemy);


            syringeCreator.GetEnemy(roomsGrid.GetChild(roomNum), roomsGrid.GetChild(roomNum).position, difX, difY);
        }

        private void Update()
        {
            // TODO: just testing, must be deleted
            foreach (Enemy enemy in enemies)
            {
                Doctor enemyA = enemy as Doctor;

                //GameObject enemyObject = enemyA.enemyObject;

                //Debug.Log(enemyObject);

                float startX = enemyA.transform.parent.position.x - 2;
                float startY = enemyA.transform.parent.position.y - 2;

                // обчислює нову позицію ворога на колі
                float x = startX + Mathf.Cos(enemyA.angle) * 1; // радіус кола - 1
                float y = startY + Mathf.Sin(enemyA.angle) * 1; // радіус кола - 1

                // оновлює позицію префаба ворога
                enemyA.transform.position = new Vector2(x, y);

                // оновлює кутову позицію ворога на колі
                enemyA.angle += Time.deltaTime; // змінюється з часом, щоб ворог рухався

                //Doctor enemyA = enemy as Doctor;
                //enemyA.enemyObject.SetActive(false);
            }
        }
    }
}