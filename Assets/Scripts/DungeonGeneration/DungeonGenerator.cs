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
        [SerializeField] private Level1EnemiesGenerator enemiesGenerator;
        [SerializeField] private Level1WeaponsGenerator weaponsGenerator;

        /// <summary>
        /// The current level of the dungeon
        /// </summary>
        private int level = 1;
        
        /// <summary>
        /// Start all generations
        /// </summary>
        private void Start()
        {
            List<Room> roomsList = layoutGenerator.Generate(level);
            roomGenerator.Generate(roomsList);
            enemiesGenerator.Generate(roomsList);
            weaponsGenerator.Generate(roomsList);
        }
    }
}

