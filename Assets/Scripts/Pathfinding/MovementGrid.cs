using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/**
* \brief A class representing a grid for pathfinding.
*/
public class MovementGrid : MonoBehaviour
{
    /// <summary>
    /// Width of the movement grid. Matches the room's width.
    /// </summary>
    private const int width = 13; // prev 18
    
    /// <summary>
    /// Height of the movement grid. Matcher the room's height.
    /// </summary>
    private const int height = 7; // prev 5
    
    /// <summary>
    /// Size of the square cell of the movement grid.
    /// </summary>
    private const float cellSize = 1f;

    /// <summary>
    /// The origin position of the grid in world coordinates.
    /// </summary>
    public Vector2 originPosition;
    
    /// <summary>
    /// Array that stores all the cells.
    /// </summary>
    private PathNode[,] gridArray;
    
    private TextMesh[,] debugTextArray;
    public const int sortingOrderDefault = 5000;
    /**
     * \brief Constructor for the MovementGrid class.
     * 
     * Creates grid and fills it with PathMode objects.
     * \param originPosition The origin position of the grid in world coordinates.
     */
   private void Start()
   {
       gridArray = new PathNode[width, height];
        
       for (int x = 0; x < gridArray.GetLength(0); x++)
       {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = new PathNode(this, x, y);
            }
       }
       debugTextArray = new TextMesh[width, height];
       for (int x = 0; x < gridArray.GetLength(0); x++)
       {
           /*for(int y = 0; y < gridArray.GetLength(1); y++)
           {
               debugTextArray[x,y] =  CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector2(cellSize, cellSize) * .5f, 5, Color.white, TextAnchor.MiddleCenter);
               Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
               Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
               gridArray[x, y] = new PathNode(this, x, y);
           }*/



       }
       //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
       //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
   }
    
   /**
    * \brief Calculates in-grid position (x, y) based on the given world position.
    * \param worldPosition The world position to convert to in-grid position.
    * \param x The output x coordinate of the in-grid position.
    * \param y The output y coordinate of the in-grid position.
    */
    public void GetInGridPosition(Vector2 worldPosition, out int x, out int y)
    {
        //Debug.Log("world position: " + worldPosition + " originPosition: " + originPosition);
        x = Mathf.FloorToInt(Mathf.Abs(worldPosition.x + Mathf.Abs(originPosition.x)) / cellSize);
        y = Mathf.FloorToInt(Mathf.Abs(worldPosition.y + Mathf.Abs(originPosition.y)) / cellSize);
        //Debug.Log("x: " +  x + " y: " + y);
    }
    
    public Vector2 GetWorldPosition(int x, int y)   
    {
        return new Vector2 (x, y) * cellSize + originPosition;
    }
    
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector2 localPosition = default(Vector2), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }
    
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




