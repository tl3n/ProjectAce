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

        public Room(int x, int y, RoomType type, List<Side> neighboringSides)
        {
            X = x;
            Y = y;
            Type = type;
            NeighboringSides = neighboringSides;
        }
    }
}


