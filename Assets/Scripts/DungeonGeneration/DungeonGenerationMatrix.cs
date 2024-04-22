using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DungeonGenerationMatrix : MonoBehaviour
{   
    /// <summary>
    /// X-position of start room in layout
    /// </summary>
    private const int LayoutStartRoomX = 4;

    /// <summary>
    /// Y-position of start room in layout
    /// </summary>
    private const int LayoutStartRoomY = 4;

    /// <summary>
    /// Distance between centres of rooms on X-coordinate
    /// </summary>
    private const int SceneRoomDistanceX = 15;

    /// <summary>
    /// Distance between centres of rooms on Y-coordinate
    /// </summary>
    private const int SceneRoomDistanceY = -9;
    
    /// <summary>
    /// Enum to represent sides in the matrix layout
    /// </summary>
    private enum Side 
    {
        Top,
        Right,
        Bottom,
        Left
    }
    
    /// <summary>
    /// Matrix that represents layout of the rooms
    /// </summary>
    private int[,] layout = new int[9, 9]
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    
    /// <summary>
    /// The current level of the dungeon
    /// </summary>
    public int level = 1;
    
    /// <summary>
    /// Number of rooms to generate
    /// </summary>
    public int numberOfRoomsToGenerate = 0;
    
    /// <summary>
    /// List that stores tuple of indexes of generated cells in the layout matrix
    /// </summary>
    private List<(int, int)> generatedLayoutCells = new List<(int, int)>();
    
    /// <summary>
    /// List that stores generated rooms
    /// </summary>
    private List<GameObject> generatedSceneRooms = new List<GameObject>();
    
    /// <summary>
    /// Number of end rooms to generate
    /// </summary>
    public int minNumberOfEndRoomsToGenerate = 3;
    
    /// <summary>
    /// List stat stores generated end rooms
    /// </summary>
    private List<(int, int)> generatedLayoutEndCells = new List<(int, int)>();

    public int bossRoomX, bossRoomY; // to see which room became boss (WILL BE REMOVED)
    public int secretRoomX, secretRoomY; // to see which room became secret (WILL BE REMOVED)

    /// <summary>
    /// The boos room
    /// </summary>
    private (int, int) bossRoomLayoutPosition;
    
    /// <summary>
    /// Prefab for a room
    /// </summary>
    public GameObject roomPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        numberOfRoomsToGenerate = Random.Range(0, 2) + 5 + level * 2;
        
        while (true)
        {
            Reset();
            GenerateLayout((LayoutStartRoomX, LayoutStartRoomY));
            FindEndCells(); 
            BossRoom();
            //SecretRoom();
            
            // Checking if layout is generated correctly
            if (generatedLayoutCells.Count == numberOfRoomsToGenerate &&
                generatedLayoutEndCells.Count >= minNumberOfEndRoomsToGenerate)
            {
                GenerateRooms();
                break;
            }
        }        
    }
    
    /**
     * \brief Setting all values to the default
     */
    private void Reset()
    {
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
            {
                layout[i, j] = 0;
            }
        }
        
        generatedLayoutCells.Clear();
        generatedLayoutEndCells.Clear();
        
        layout[LayoutStartRoomX, LayoutStartRoomY] = 1;
        generatedLayoutCells.Add((LayoutStartRoomX, LayoutStartRoomY));
    }
    
    /**
     * \brief Generating neighbours on the random sided for the cell
     * \param currentCell Tuple position of the cell to generate neighbours for
     */
    private void GenerateLayout((int, int) currentCell)
    {
        List<Side> sidesToGenerate = new List<Side>();
        
        // Choosing random sides to generate room spawn points on
        while (sidesToGenerate.Count == 0)
        {
            if (Random.Range(0, 2) == 0)
                sidesToGenerate.Add(Side.Top);
            
            if (Random.Range(0, 2) == 0)
                sidesToGenerate.Add(Side.Right);
            
            if (Random.Range(0, 2) == 0)
                sidesToGenerate.Add(Side.Bottom);
            
            if (Random.Range(0, 2) == 0)
                sidesToGenerate.Add(Side.Left);
        }

        foreach (Side side in sidesToGenerate)
        {
            var neighbourPosition = FindNeighbourPosition(currentCell, side);
            // Checking if the cell is out of range
            if (neighbourPosition == (-1, -1))
                continue;
                
            // Checking if the cell is already occupied
            if (layout[neighbourPosition.Item1, neighbourPosition.Item2] == 1)
                continue;
            
            // Checking if the cell already has more than one neighbour
            if (!HasOnlyOneNeighbour(neighbourPosition))
                continue;
            
            // Checking if we already have enough rooms
            if (numberOfRoomsToGenerate == generatedLayoutCells.Count)
                return;
            
            // Random chance to give up
            if (Random.Range(0, 2) == 0)
                continue;
            
            generatedLayoutCells.Add(neighbourPosition);
            layout[neighbourPosition.Item1, neighbourPosition.Item2] = 1;
            GenerateLayout(neighbourPosition);
        }
    }

    /**
     * \brief Calculating neighbour position for the cell in the layout matrix based on side you provide
     * \param currentPosition Indexes in the layout matrix of the cell you want to find neighbour position for
     * \param side Side of the neighbour which position you want to calculate
     * \return Tuple of the indexes of the neighbour cell
     */
    private (int, int) FindNeighbourPosition((int, int) currentPosition, Side side)
    {
        int currentX = currentPosition.Item1;
        int currentY = currentPosition.Item2;
        var neighbourPosition = (0, 0);
        switch (side)
        {
            case Side.Top:
                neighbourPosition = (currentX, currentY + 1);
                break;
            case Side.Right:
                neighbourPosition = (currentX + 1, currentY);
                break;
            case Side.Bottom:
                neighbourPosition = (currentX, currentY - 1);
                break;
            case Side.Left:
                neighbourPosition = (currentX - 1, currentY);
                break;
        }

        if (neighbourPosition.Item1 < 0 || neighbourPosition.Item1 > 8 || neighbourPosition.Item2 < 0 ||
            neighbourPosition.Item2 > 8)
            return (-1, -1);

        return neighbourPosition;
    }

    /**
     * \brief Counting neighbours of the cell with provided position in the layout matrix
     * \param currentPosition Tuple of indexes of the cell in the layout matrix
     * \return Number of neighbours
     */
    private int CountNeighbours((int, int) currentPosition)
    {
        int x = currentPosition.Item1;
        int y = currentPosition.Item2;
        
        Debug.Log(x + y);
        int numberOfNeighbours = 0;
        // Check top neighbor
        if (y > 0 && layout[x, y - 1] == 1)
            ++numberOfNeighbours;

        // Check right neighbor
        if (x < 8 && layout[x + 1, y] == 1)
            ++numberOfNeighbours;

        // Check bottom neighbor
        if (y < 8 && layout[x, y + 1] == 1)
            ++numberOfNeighbours;

        // Check left neighbor
        if (x > 0 && layout[x - 1, y] == 1)
            ++numberOfNeighbours;

        return numberOfNeighbours;
    }
    
    /**
     * \brief Checking if cell with provided position in the layout matrix has only one neighbour
     * \param currentPosition Tuple of indexes of the cell in the layout matrix
     * \return "True" if cell has only one neighbour, "False" otherwise
     */
    private bool HasOnlyOneNeighbour((int, int) currentPosition)
    {
        return CountNeighbours(currentPosition) == 1;
    }

    /**
     * \brief Instantiating room prefabs based on the matrix layout
     */
    private void GenerateRooms()
    {
        foreach ((int, int) cell in generatedLayoutCells)
        {
            // boss room == general room ???????
            if (layout[cell.Item1, cell.Item2] == 1 || layout[cell.Item1, cell.Item2] == 2)
            {
                int x = (cell.Item1 - LayoutStartRoomX) * SceneRoomDistanceX;
                int y = (cell.Item2 - LayoutStartRoomY) * SceneRoomDistanceY;
                Vector2 position = new Vector2(x, y);

                GameObject room = Instantiate(roomPrefab, GameObject.FindGameObjectWithTag("Grid").transform,
                    true);
                room.transform.position = position;
            }
        }
    }

    /**
     * \brief Finding end cells and adding them to the generatedEndCells list
     */
    private void FindEndCells()
    {
        foreach ((int, int) cell in generatedLayoutCells)
        {
            if (HasOnlyOneNeighbour(cell) && cell != (LayoutStartRoomX, LayoutStartRoomY))
            {
                generatedLayoutEndCells.Add(cell);
            }
        }
    }

    /**
     * \brief Finding the farthest end cell and turning it into a boss room 
     * 
     * It is not always farthest because can be situation when way to some room is the longest, 
     * but by coordinates it is not. �his algorithm should be enough for the boss room 
     * to be far from the starting room.
     */
    private void BossRoom()
    {
        int maxDistance = 0;
    
        // TODO: change to foreach?
        for (int i = 0; i < generatedLayoutEndCells.Count; ++i)
        {
            int x = generatedLayoutEndCells[i].Item1 - LayoutStartRoomX;
            int y = generatedLayoutEndCells[i].Item2 - LayoutStartRoomY;

            int distance = x * x + y * y;

            if (maxDistance < distance)
            {
                maxDistance = distance;
                bossRoomX = generatedLayoutEndCells[i].Item1; // MUST BE REMOVED
                bossRoomY = generatedLayoutEndCells[i].Item2; // MUST BE REMOVED
                bossRoomLayoutPosition = generatedLayoutEndCells[i];
            }
        }

        layout[bossRoomLayoutPosition.Item1, bossRoomLayoutPosition.Item2] = 2;
    }

    /**
     * \brief �hecking if cell has in neighbours an end room
     * \param currentPosition Tuple of indexes of the cell in the layout matrix
     * \return "True" if it has, "False" otherwise
     */
    private bool HasEndCellInNeighbours((int, int) currentPosition)
    {
        int x = currentPosition.Item1;
        int y = currentPosition.Item2;
        
        // Check top neighbor
        if (HasOnlyOneNeighbour((x, y - 1)))
            return true;

        // Check right neighbor
        if (HasOnlyOneNeighbour((x + 1, y)))
            return true;

        // Check bottom neighbor
        if (HasOnlyOneNeighbour((x, y + 1)))
            return true;

        // Check left neighbor
        return HasOnlyOneNeighbour((x - 1, y));
    }
    
    
    // TODO: do we even need secret rooms? should be discussed with other and then refactored if needed
    /**
     * \brief Finding empty cell for secret room
     * 
     * First we try to find empty cell with 3 neighbours, than 2, than 1
     */
    /*
    private void SecretRoom()
    {
        if (!SecretRoomPlace(3))
            if (!SecretRoomPlace(2))
                SecretRoomPlace(1);
    }
    */
    /**
     * \brief Finding empty cell for secret room with a specific number of neighbors
     * \param condition Number of neighbours
     * \return "True" if we find needed cell, "False" otherwise
     */
    /*
    private bool SecretRoomPlace(int condition)
    {
        // first attempt 300, next 600, next 900
        for (int i = 0; i < (4 - condition) * 300; ++i)
        {
            int x = Random.Range(0, 9);
            int y = Random.Range(0, 9);

            int numberOfNeighbours = CountNeighbours((x, y));

            if (layout[x, y] == 0 && numberOfNeighbours >= condition && !HasEndCellInNeighbours((x, y)))
            {
                secretRoomX = x;
                secretRoomY = y;

                return true;
            }
        }

        return false;
    }
    */
}
