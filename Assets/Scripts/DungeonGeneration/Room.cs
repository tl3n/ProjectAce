using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGeneration
{
    public class Room : GridComponent
    {
        /// <summary>
        /// X-coordinate of the room's center
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-coordinate of the room's center
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Type of the room
        /// </summary>
        public RoomType Type { get; set; }

        /// <summary>
        /// Sides where room has neighbours
        /// </summary>
        public List<Side> NeighboringSides { get; set; }

        /// <summary>
        /// List of the components in the room
        /// </summary>
        protected List<GridComponent> _children = new List<GridComponent>();

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

        /// <summary>
        /// Add component into the list 
        /// </summary>
        /// <param name="component">Grid component</param>
        public void Add(GridComponent component)
        {
            this._children.Add(component);
        }

        /// <summary>
        /// Remove component from the list 
        /// </summary>
        /// <param name="component">Grid component</param>
        public void Remove(GridComponent component)
        {
            this._children.Remove(component);
        }

        /// <summary>
        /// Returns name of the grid components
        /// </summary>
        /// <returns>List of the components</returns>
        public string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (GridComponent component in this._children)
            {
                result += component.Operation();
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }

        /// <summary>
        /// Check if component is composite
        /// </summary>
        /// <returns>True</returns>
        public bool IsComposite()
        {
            return true;
        }

        /// <summary>
        /// Change state of the components
        /// </summary>
        /// <param name="state">State to which it will be changed</param>
        public void SetActive(bool state)
        {
            foreach (GridComponent component in this._children)
            {
                component.SetActive(state);
            }
        }
    }
}


