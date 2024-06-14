using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* \brief Represents a node in the movement grid.
*/
public class PathNode
{
    /// <summary>The movement grid this node belongs to.</summary>
    private MovementGrid grid;
    
    /// <summary>The x-coordinate of the node in the grid.</summary>
    private int x;
    
    /// <summary>The y-coordinate of the node in the grid.</summary>
    private int y;
    
    /// <summary>The size of a single cell in the grid.</summary>
    private float cellSize;
    
    /// <summary>Whether the node is walkable or not.</summary>
    private bool isWalkable;
    
    /// <summary>The cost from the start node to this node.</summary>
    public int gCost;
    
    /// <summary>The estimated cost from this node to the end node.</summary>
    public int hCost;
    
    /// <summary>The total cost (gCost + hCost).</summary>
    public int fCost;

    // <summary>The node this node was reached from.</summary>
    public PathNode cameFromNode;

    /**
     * \brief Constructs a new PathNode.
     * \param grid The movement grid this node belongs to.
     * \param x The x-coordinate of the node in the grid.
     * \param y The y-coordinate of the node in the grid.
     */
    public PathNode(MovementGrid grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        cellSize = grid.GetCellSize();
        isWalkable = IsWalkable();
    }

    /**
     * \brief Checks if the node is walkable.
     * \return True if the node is walkable, false otherwise.
     */
    private bool IsWalkable()
    {
        LayerMask unwalkableMask = LayerMask.NameToLayer("Unwalkable");
        Vector2 worldPoint = FindWorldPosition();
        Vector2 box = new Vector2(cellSize - .1f, cellSize - .1f);
        
        return !(Physics2D.OverlapBox(worldPoint, box, 0, 1 << unwalkableMask));
    }
    
    /**
     * \brief Finds the world position of the node.
     * \return The world position of the node.
     */
    private Vector2 FindWorldPosition()
    {
        Vector2 originPosition = grid.GetOriginPosition();
        return new Vector2(x * cellSize + 2.5f, y * cellSize + 2.5f) + originPosition;
    }
    
    /**
     * \brief Calculates the fCost (gCost + hCost) for this node.
     */
    public void CalculateFCost()
    {
        fCost = hCost + gCost;
    }
    
    /**
     * \brief Returns a string representation of the node's coordinates.
     * \return A string in the format "x,y".
     */
    public override string ToString()
    {
        return x + "," + y;
    }

    /**
     * \brief Gets the x-coordinate of the node in the grid.
     * \return The x-coordinate of the node.
     */
    public int GetX()
    {
        return x;
    }

    /**
    * \brief Gets the y-coordinate of the node in the grid.
    * \return The y-coordinate of the node.
    */
    public int GetY()
    {
        return y;
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
     * \brief Gets whether the node is walkable or not.
     * \return True if the node is walkable, false otherwise.
     */
    public bool GetIsWalkable()
    {
        return isWalkable;
    }
}
