using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonGeneration
{
    public class RoomGenerator : MonoBehaviour
    {
        /// <summary>
        /// Distance between centres of rooms on X-coordinate
        /// </summary>
        private const int SceneRoomDistanceX = 15;

        /// <summary>
        /// Distance between centres of rooms on Y-coordinate
        /// </summary>
        private const int SceneRoomDistanceY = -9;

        /// <summary>
        /// Prefab for a room
        /// </summary>
        public GameObject roomPrefab;

        /// <summary>
        /// Instantiating room prefabs based on the matrix layout
        /// </summary>
        /// <param name="roomsList">List of the generated rooms</param>
        public void Generate(List<Room> roomsList)
        {
            // TODO: refactor this shit to the factory pattern or something idk
            // TODO: idi nahui
            foreach (var room in roomsList)
            {
                RoomType type = room.Type;
                switch (type)
                {
                    case RoomType.Start:
                        // choose starting room prefab
                        break;
                    case RoomType.EnemyEasy:
                        // choose enemy easy room prefab
                        break;
                    case RoomType.EnemyMedium:
                        // choose enemy medium room prefab
                        break;
                    case RoomType.EnemyHard:
                        // choose enemy hard room prefab
                        break;
                    case RoomType.Treasure:
                        // choose treasure room prefab
                        break;
                    case RoomType.Boss:
                        // choose boss room prefab
                        break;
                }

                Vector2 scenePosition = new Vector2(room.X, room.Y);
                
                // TODO: change roomPrefab to the type-based room prefab
                GameObject instance = Instantiate(roomPrefab, GameObject.FindGameObjectWithTag("Grid").transform, true);
                instance.transform.position = scenePosition;

                ActivateDoors(instance, room.NeighboringSides);
            }
        }

        /// <summary>
        /// Activation of doors
        /// </summary>
        /// If there is neighbour on the side activate door and deactivate block
        /// <param name="room">Selected room</param>
        /// <param name="neighboringSides">List of the room's neighbours</param>
        private void ActivateDoors(GameObject room, List<Side> neighboringSides)
        {
            // TODO: Vasia cho ty tvorish, why initialization was inside of foreach?????
            // TODO: deleting instead of activation
            Transform topDoor = room.transform.Find("TopDoor");
            Transform topBlock = room.transform.Find("TopBlock");

            Transform rightDoor = room.transform.Find("RightDoor");
            Transform rightBlock = room.transform.Find("RightBlock");

            Transform bottomDoor = room.transform.Find("BottomDoor");
            Transform bottomBlock = room.transform.Find("BottomBlock");

            Transform leftDoor = room.transform.Find("LeftDoor");
            Transform leftBlock = room.transform.Find("LeftBlock");

            foreach (var side in neighboringSides)
            {
                switch (side)
                {
                    case Side.Top:
                        topDoor.gameObject.SetActive(true);
                        topBlock.gameObject.SetActive(false);
                        break;
                    case Side.Right:
                        rightDoor.gameObject.SetActive(true);
                        rightBlock.gameObject.SetActive(false);
                        break;
                    case Side.Bottom:
                        bottomDoor.gameObject.SetActive(true);
                        bottomBlock.gameObject.SetActive(false);
                        break;
                    case Side.Left:
                        leftDoor.gameObject.SetActive(true);
                        leftBlock.gameObject.SetActive(false);
                        break;
                }
            }
        }
        
}
}
