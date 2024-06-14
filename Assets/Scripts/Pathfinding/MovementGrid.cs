using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* \brief A class representing a grid for pathfinding.
*/
public class MovementGrid
{
    /// <summary>
    /// Width of the movement grid. Matches the room's width.
    /// </summary>
    private const int width = 18;
    
    /// <summary>
    /// Height of the movement grid. Matcher the room's height.
    /// </summary>
    private const int height = 5;
    
    /// <summary>
    /// Size of the square cell of the movement grid.
    /// </summary>
    private const float cellSize = 5f;

    /// <summary>
    /// The origin position of the grid in world coordinates.
    /// </summary>
    private Vector2 originPosition;
    
    /// <summary>
    /// Array that stores all the cells.
    /// </summary>
    private PathNode[,] gridArray;   
    
    /**
     * \brief Constructor for the MovementGrid class.
     * 
     * Creates grid and fills it with PathMode objects.
     * \param originPosition The origin position of the grid in world coordinates.
     */
   public MovementGrid(Vector2 originPosition)
    {
        this.originPosition = originPosition;
        
        gridArray = new PathNode[width, height];
        
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = new PathNode(this, x, y);
            }
        }
        
    }
    
   /**
    * \brief Calculates in-grid position (x, y) based on the given world position.
    * \param worldPosition The world position to convert to in-grid position.
    * \param x The output x coordinate of the in-grid position.
    * \param y The output y coordinate of the in-grid position.
    */
    public void GetInGridPosition(Vector2 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }
    
    /**
    * \brief Gets the PathNode at the specified in-grid coordinates.
    * \param x The x coordinate of the in-grid position.
    * \param y The y coordinate of the in-grid position.
    * \return The PathNode at the specified in-grid position, or default if out of bounds.
    */
    public PathNode GetPathNode(int x, int y)
    {
        if (x>=0 && y>= 0 && x< width && y< height)
        {
            return gridArray[x, y];
        }

        return default;
    }

    /**
    * \brief Gets the PathNode at the specified world position.
    * \param worldPosition The world position to get the PathNode for.
    * \return The PathNode at the specified world position, or default if out of bounds.
    */
    public PathNode GetPathNode(Vector2 worldPosition)
    {
        int x, y;
        GetInGridPosition(worldPosition, out x, out y);
        return GetPathNode(x, y);
    }
    
    /**
    * \brief Gets the width of the grid.
    * \return The width of the grid.
    */
    public int GetWidth()
    {
        return width;
    }
    
    /**
    * \brief Gets the height of the grid.
    * \return The height of the grid.
    */
    public int GetHeight()
    {
        return height;
    }
    
    /**
    * \brief Gets the size of a single cell in the grid.
    * \return The size of a single cell.
    */
    public float GetCellSize()
    {
        return cellSize;
    }

    /**
    * \brief Gets the origin position of the grid in world coordinates.
    * \return The origin position of the grid.
    */
    public Vector2 GetOriginPosition()
    {
        return originPosition;
    }
    
}




