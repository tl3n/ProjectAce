using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid
{

    private int width;
    private int height;
    private float cellSize;
    public const int sortingOrderDefault = 5000;
    private Vector2 originPosition;
    
    private PathNode[,] gridArray;   
    private TextMesh[,] debugTextArray;
    
   public MovementGrid(Vector2 originPosition)
    {
        this.width = 18;
        this.height = 5;
        this.cellSize = 5f; 
        this.originPosition = originPosition;
        
        gridArray = new PathNode[width, height];
        debugTextArray = new TextMesh[width, height];
        
        LayerMask unwalkableMask = LayerMask.NameToLayer("Unwalkable");
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Vector2 worldPoint = new Vector2(x * cellSize + 2.5f, y * cellSize + 2.5f);
                Vector2 box = new Vector2(cellSize - .1f, cellSize - .1f);
                bool isWalkable = !(Physics2D.OverlapBox(worldPoint, box, 0, 1 << unwalkableMask)); 
                
                gridArray[x, y] = createGridObject(this, x, y, isWalkable);
            }
        }


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] =  CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector2(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
           

            
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        
    }

    PathNode createGridObject(MovementGrid grid, int x, int y, bool isWalkable)
    {
        return new PathNode(grid, x, y, isWalkable);
    }

    private Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2 (x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector2 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
        //Debug.Log(x + " " + y);
    }

    public void SetGridObject(int x, int y, PathNode value)
    {
        if(x>= 0 && y>=0 && x< width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
        
    }

    public void SetGridObject(Vector2 worldPosition, PathNode value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }

    public PathNode GetGridObject(int x, int y)
    {
        if (x>=0 && y>= 0 && x< width && y< height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(PathNode);
        }
    }

    public PathNode GetGridObject(Vector2 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }


    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector2 localPosition = default(Vector2), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // Create Text in the World
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
    
    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }
}



