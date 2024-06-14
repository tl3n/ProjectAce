using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/**
* \brief Class for finding paths using the A* algorithm.
*/
public class Pathfinding
{
    /// <summary>The cost for moving straight (horizontally or vertically).</summary>
    private const int MOVE_STRAIGHT_COST = 10;
    
    /// <summary>The cost for moving diagonally.</summary>
    private const int MOVE_DIAGONAL_COST = 14;
    
    /// <summary>The singleton instance of the Pathfinding class.</summary>
    public static Pathfinding Instance { get; private set; }
    
    /// <summary>The movement grid used for pathfinding.</summary>
    private MovementGrid grid;
    
    /// <summary>The list of nodes to be evaluated.</summary>
    private List<PathNode> openList;
    
    /// <summary>The list of nodes that have been evaluated.</summary>
    private List<PathNode> closedList;
    
    /**
    * \brief Constructs a new Pathfinding instance.
    */
    public Pathfinding()
    {
        Instance = this;

        Vector2 originPosition = new Vector2(0, 0);
        this.grid = new MovementGrid(originPosition);
    }

    /**
    * \brief Finds the path between two world positions.
    * \param startWorldPosition The starting world position.
    * \param endWorldPosition The ending world position.
    * \return The list of Vector3 positions representing the path, or null if no path is found.
    */
    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        grid.GetInGridPosition(startWorldPosition, out int startX, out int startY);
        grid.GetInGridPosition(endWorldPosition, out int endX, out int endY);
        
        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path == null)
        {
            return null;
        }
        else
        {
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (PathNode pathNode in path)
            {
                vectorPath.Add(new Vector3(pathNode.GetX(), pathNode.GetY()) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f);
            }
            return vectorPath;
        }
    }
    
    /**
    * \brief Finds the path between two grid positions using the A* algorithm.
    * \param startX The x-coordinate of the starting grid position.
    * \param startY The y-coordinate of the starting grid position.
    * \param endX The x-coordinate of the ending grid position.
    * \param endY The y-coordinate of the ending grid position.
    * \return The list of PathNodes representing the path, or null if no path is found.
    */
    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.GetPathNode(startX, startY);
        PathNode endNode = grid.GetPathNode(endX, endY);
        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode pathNode = grid.GetPathNode(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbourNode in GetNeigbourList(currentNode))
            {
                if (closedList.Contains(neighbourNode))
                    continue;

                if (!neighbourNode.GetIsWalkable())
                {
                    closedList.Add(neighbourNode);
                    continue;
                }
                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        return null;
    }

    /**
    * \brief Gets the PathNode at the specified grid coordinates.
    * \param x The x-coordinate of the grid position.
    * \param y The y-coordinate of the grid position.
    * \return The PathNode at the specified grid position.
    */
    public PathNode GetNode(int x, int y)
    {
        return grid.GetPathNode(x, y);
    }
    
    /**
   * \brief Calculates the path from the end node to the start node.
   * \param endNode The end node of the path.
   * \return The list of PathNodes representing the path from the start node to the end node.
   */
    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }

    /**
    * \brief Gets the list of neighboring nodes for a given node.
    * \param currentNode The node for which to get the neighboring nodes.
    * \return The list of PathNodes representing the neighboring nodes.
    */
    private List<PathNode> GetNeigbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();
        int x = currentNode.GetX();
        int y = currentNode.GetY();
        
        if (x - 1 >= 0)
        {
            //Left
            neighbourList.Add(GetNode(x - 1, y));
            //Left Down
            if(y - 1 >= 0)
                neighbourList.Add(GetNode(x - 1, y - 1));
            //Left Up
            if (y + 1 < grid.GetHeight())
                neighbourList.Add(GetNode(x - 1, y + 1));
        }

        if (x + 1 < grid.GetWidth())
        {
            //Right
            neighbourList.Add(GetNode(x + 1, y));
            //Right Down
            if (y - 1 >= 0) 
                neighbourList.Add(GetNode(x + 1, y - 1));
            //Right Up
            if (y + 1 < grid.GetHeight()) 
                neighbourList.Add(GetNode(x + 1, y + 1));
        }
        
        //Down
        if(y - 1 >= 0)
            neighbourList.Add(GetNode(x, y - 1));
        //Up
        if(y + 1 < grid.GetHeight())
            neighbourList.Add(GetNode(x, y + 1));

        return neighbourList;
    }
    
    /**
    * \brief Calculates the distance cost between two nodes.
    * \param a The first node.
    * \param b The second node.
    * \return The distance cost between the two nodes.
    */
    private int CalculateDistanceCost(PathNode a, PathNode b)
    {

        int xDistance = Mathf.Abs(a.GetX() - b.GetX());
        int yDistance = Mathf.Abs(a.GetY() - b.GetY());
        int remaining = Mathf.Abs(xDistance - yDistance);

        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }
    
    /**
    * \brief Gets the node with the lowest fCost from the list of PathNodes.
    * \param pathNodeList The list of PathNodes to search.
    * \return The PathNode with the lowest fCost.
    */
    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];

        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }

        return lowestFCostNode;
    }

    /**
   * \brief Gets the movement grid used for pathfinding.
   * \return The movement grid used for pathfinding.
   */
    public MovementGrid GetGrid()
    {
        return grid;
    }

}
