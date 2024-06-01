using System.Collections.Generic;
using UnityEngine;
using DungeonGeneration;
using UnityEditorInternal;

namespace RoomGeneration
{
    public class Level1EnemiesGenerator : EnemiesFactory
    {
        /// <summary>
        /// Fabric for melle enemy
        /// </summary>
        [SerializeField] protected MelleEnemiesCreator melleEnemiesCreator;

        /// <summary>
        /// Fabric for ranger enemy
        /// </summary>
        [SerializeField] protected RangerEnemiesCreator rangerEnemiesCreator;

        /// <summary>
        /// Fabric for summoner enemy
        /// </summary>
        [SerializeField] protected SummonerEnemiesCreator summonerEnemiesCreator;

        /// <summary>
        /// Fabric for boss enemy
        /// </summary>
        [SerializeField] protected BossEnemiesCreator bossEnemiesCreator;

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
                CreateEnemies(roomsList[i].Type, i, roomsList[i]);
                //roomsList[i].SetActive(true);
                roomsList[i].SetActive(false);
            }
        }

        /// <summary>
        /// Generation of enemies for selected room
        /// </summary>
        /// <param name="roomType">Type of the room</param>
        /// <param name="roomNum">Number of the room in grid</param>
        private void CreateEnemies(RoomType roomType, int roomNum, Room room) 
        {
            // TODO: write here logic of generation

            // TODO: just testing, must be edited
            int difX = 0, difY = 0;

            if (roomType == RoomType.Start)
                difX = difY = 2;
            else
                difX = difY = 0;

            Enemy enemy1, enemy2;

            enemy1 = melleEnemiesCreator.GetEnemy(roomsGrid.GetChild(roomNum), roomsGrid.GetChild(roomNum).position, difX, difY);
            EnemyStateMachine stateMachine1 = new EnemyStateMachine(enemy1);
            stateMachine1.Initialize(stateMachine1.passiveState);
            //Debug.Log(enemy1.GetName());
            //Debug.Log(enemy1.IsComposite());

            room.Add(enemy1);

            //if (enemy != null) enemies.Add(enemy);

            enemies.Add(enemy1);


            enemy2 = rangerEnemiesCreator.GetEnemy(roomsGrid.GetChild(roomNum), roomsGrid.GetChild(roomNum).position, difX, difY);
            EnemyStateMachine stateMachine2 = new EnemyStateMachine(enemy2);
            stateMachine2.Initialize(stateMachine2.passiveState);
            //Debug.Log(enemy2.GetName());
            //Debug.Log(enemy2.IsComposite());

            room.Add(enemy2);
            //Debug.Log(room.GetName());
            //Debug.Log(room.IsComposite());
        }

        private void Update()
        {
            // TODO: just testing, must be deleted
            //foreach (Enemy enemy in enemies)
            //{
            //    EnemyStateMachine stateMachine = new EnemyStateMachine(enemy);
            //    stateMachine.Initialize(stateMachine.activeState);
            //    stateMachine.Update();
            //}
        }
    }
}