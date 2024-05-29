using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{

    private MovementGrid<PathNode> grid;
    [SerializeField] private float cellSize = 5f;
    public Pathfinding(int width, int height)
    {
        grid = new MovementGrid<PathNode>(width, height, cellSize, new Vector2(-45, -16), (MovementGrid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }
}
