using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DungeonGeneration
{
    
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] private LayoutGenerator layoutGenerator;
        [SerializeField] private RoomGenerator roomGenerator;
        
        /// <summary>
        /// The current level of the dungeon
        /// </summary>
        private int level = 1;
        
        private void Start()
        {
            List<Room> roomsList = layoutGenerator.Generate(level);

            /*foreach (var room in roomsList)
            {
                Debug.Log("X: " + room.X + " Y: " + room.Y);
            }*/
            
            roomGenerator.Generate(roomsList);
        }
    }
}

