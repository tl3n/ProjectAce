using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using RoomGeneration;

namespace DungeonGeneration
{
    
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] private LayoutGenerator layoutGenerator;
        [SerializeField] private RoomGenerator roomGenerator;
        [SerializeField] private EnemiesGenerator enemiesGenerator;

        /// <summary>
        /// The current level of the dungeon
        /// </summary>
        private int level = 1;
        
        private void Start()
        {
            List<Room> roomsList = layoutGenerator.Generate(level);
            roomGenerator.Generate(roomsList);
            enemiesGenerator.Generate(roomsList);
        }
    }
}

