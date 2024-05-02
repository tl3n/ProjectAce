using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGeneration
{
    public class Room
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoomType Type { get; set; }
        public List<Side> NeighboringSides { get; set; }

        /// <summary>
        /// Initialization of the room
        /// </summary>
        /// <param name="x">X-coordinate of the room</param>
        /// <param name="y">Y-coordinate of the room</param>
        /// <param name="type">Type of the room</param>
        /// <param name="neighboringSides">Sides, where room has neighbours</param>
        public Room(int x, int y, RoomType type, List<Side> neighboringSides)
        {
            X = x;
            Y = y;
            Type = type;
            NeighboringSides = neighboringSides;
        }
    }
}


