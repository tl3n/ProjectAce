using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DungeonGeneration;
using UnityEngine.UIElements;
using static PlasticGui.LaunchDiffParameters;

namespace RoomGeneration
{
    public class EnemiesGenerator : MonoBehaviour
    {
        [SerializeField] private EnemyACreator enemyACreator;
        [SerializeField] private EnemyBCreator enemyBCreator;

        public GameObject enemyPrefab;
        public Transform grid;

        private List<Enemy> enemies = new List<Enemy>();

        private int difX = 0, difY = 0;

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

        private void CreateEnemies(RoomType roomType, int i) 
        {
            if (roomType == RoomType.Start)
                difX = difY = 2;
            else
                difX = difY = 0;

            //Vector2 position = new Vector2(grid.GetChild(i).position.x + difX, grid.GetChild(i).position.y + difY);
            //GameObject newObject = Instantiate(enemyPrefab, position, Quaternion.identity, grid.GetChild(i));

            //Debug.Log(grid.GetChild(i));

            Enemy enemy;

            enemy = enemyACreator.GetEnemy(grid.GetChild(i), grid.GetChild(i).position, difX, difY);

            Debug.Log(enemy);

            //if (enemy != null) enemies.Add(enemy);

            enemies.Add(enemy);


            enemyBCreator.GetEnemy(grid.GetChild(i), grid.GetChild(i).position, difX, difY);
        }

        private void Update()
        {
            foreach (Enemy enemy in enemies)
            {
                EnemyA enemyA = enemy as EnemyA;

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

                //EnemyA enemyA = enemy as EnemyA;
                //enemyA.enemyObject.SetActive(false);
            }
        }
    }
}