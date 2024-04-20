using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DungeonGenerationMatrix : MonoBehaviour
{   
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
    public int[,] layout = new int[9, 9]
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
    /// X-position of start room in layout
    /// </summary>
    private int startX = 4;

    /// <summary>
    /// Y-position of start room in layout
    /// </summary>
    private int startY = 4;

    /// <summary>
    /// Distance between centres of rooms on X-coordinate
    /// </summary>
    private int distanceX = 15;

    /// <summary>
    /// Distance between centres of rooms on Y-coordinate
    /// </summary>
    private int distanceY = -9;
    
    /// <summary>
    /// Number of rooms to generate
    /// </summary>
    public int numberOfRoomsToGenerate = 0;
    
    /// <summary>
    /// List that stores tuple of indexes of generated cells in the layout matrix
    /// </summary>
    private List<(int, int)> generatedCells = new List<(int, int)>();
    
    /// <summary>
    /// List that stores generated rooms
    /// </summary>
    private List<GameObject> generatedRooms = new List<GameObject>();
    
    /// <summary>
    /// Number of end rooms to generate
    /// </summary>
    public int MinNumberOfEndRoomsToGenerate = 3;
    
    /// <summary>
    /// List stat stores generated end rooms
    /// </summary>
    private List<(int, int)> generatedEndCells = new List<(int, int)>();

    public int bossRoomX, bossRoomY; // to see which room became boss (WILL BE REMOVED)

    /// <summary>
    /// The boos room
    /// </summary>
    private (int, int) bossRoom;

    /// <summary>
    /// The current level of the dungeon
    /// </summary>
    public int level = 1;
    
    /// <summary>
    /// Prefab for a room
    /// </summary>
    public GameObject roomPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfRoomsToGenerate = Random.Range(0, 2) + 5 + level * 2;
        
        while (true)
        {
            GenerateNeighbours((startX, startY));
            FindEndCells();
            BossRoom();

            foreach ((int, int) cell in generatedEndCells)
            {
                Debug.Log(cell.Item1 + cell.Item2);
            }
            
            if (generatedCells.Count != numberOfRoomsToGenerate || generatedEndCells.Count < MinNumberOfEndRoomsToGenerate)
            {
                Reset();
            }
            else
            {
                GenerateRooms();
                break;
            }
        }        
    }

    /**
     * \brief Generating neighbours on the random sided for the cell
     * \param currentCell Tuple position of the cell to generate neighbours for
     */
    private void GenerateNeighbours((int, int) currentCell)
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
            var neighbourPosition = GetNeighbourPosition(currentCell, side);
            // Checking if the cell is out of range
            if (neighbourPosition == (-1, -1))
                continue;
                
            // Checking if the cell is already occupied
            if (layout[neighbourPosition.Item1, neighbourPosition.Item2] == 1)
                continue;
            
            // Checking if the cell already has more than one neighbour
            if (!OnlyOneNeighbour(neighbourPosition))
                continue;
            
            // Checking if we already have enough rooms
            if (numberOfRoomsToGenerate == generatedCells.Count)
                return;
            
            // Random chance to give up
            if (Random.Range(0, 2) == 0)
                continue;
            
            generatedCells.Add(neighbourPosition);
            layout[neighbourPosition.Item1, neighbourPosition.Item2] = 1;
            GenerateNeighbours(neighbourPosition);
        }
    }

    /**
     * \brief Calculating neighbour position for the cell in the layout matrix based on side you provide
     * \param currentPosition Indexes in the layout matrix of the cell you want to find neighbour position for
     * \param side Side of the neighbour which position you want to calculate
     * \return Tuple of the indexes of the neighbour cell
     */
    private (int, int) GetNeighbourPosition((int, int) currentPosition, Side side)
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
     * \brief Checking if cell with provided position in the layout matrix has only one neighbour
     * \param currentPosition Tuple of indexes of the cell in the layout matrix
     * \return "True" if cell has only one neighbour, "False" otherwise
     */
    private bool OnlyOneNeighbour((int, int) currentPosition)
    {
        int x = currentPosition.Item1;
        int y = currentPosition.Item2;
        
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

        return numberOfNeighbours == 1;
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

        layout[startX, startY] = 1;
        generatedCells.Clear();
        generatedCells.Add((startX, startY));
        
        generatedEndCells.Clear();
    }

    /**
     * \brief Instantiating room prefabs based on the matrix layout
     */
    private void GenerateRooms()
    {
        foreach ((int, int) cell in generatedCells)
        {
            // boss room == general room ???????
            if (layout[cell.Item1, cell.Item2] == 1 || layout[cell.Item1, cell.Item2] == 2)
            {
                int x = (cell.Item1 - startX) * distanceX;
                int y = (cell.Item2 - startY) * distanceY;
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
        foreach ((int, int) cell in generatedCells)
        {
            if (OnlyOneNeighbour(cell) && cell != (startX, startY))
            {
                generatedEndCells.Add(cell);
            }
        }
    }

    /**
     * \brief Finding the farthest end cell and turning it into a boss room 
     * 
     * It is not always farthest because can be situation when way to some room is the longest, 
     * but by coordinates it is not. Åhis algorithm should be enough for the boss room 
     * to be far from the starting room.
     */
    private void BossRoom()
    {
        int maxDistance = 0;

        for (int i = 0; i < generatedEndCells.Count; ++i)
        {
            int distance = (generatedEndCells[i].Item1 - startX) * (generatedEndCells[i].Item1 - startX) 
                           + (generatedEndCells[i].Item2 - startY) * (generatedEndCells[i].Item2 - startY);

            if (maxDistance < distance)
            {
                maxDistance = distance;
                bossRoomX = generatedEndCells[i].Item1; // MUST BE REMOVED
                bossRoomY = generatedEndCells[i].Item2; // MUST BE REMOVED
                bossRoom = generatedEndCells[i];
            }
        }

        layout[bossRoom.Item1, bossRoom.Item2] = 2;
    }
}
