using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private MovementGrid grid;
    public int x;
    public int y;

    public bool isWalkable;
    
    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    public PathNode(MovementGrid grid, int x, int y, bool isWalkable = true)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
    }

   
    public void CalculateFCost()
    {
        fCost = hCost + gCost;
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
    }
    
    public override string ToString()
    {
        return x + "," + y;
    }
}
