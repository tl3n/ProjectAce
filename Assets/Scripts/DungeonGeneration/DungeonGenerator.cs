using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int level = 1;
    public GameObject roomSpawnPointPrefab;
    private int RoomsToCreate { get; set; }

    private int CurrentNumberOfRooms { get; set; }
    
    private List<GameObject> roomSpawnPoints = new List<GameObject>();
    private enum Side
    {
        Top,
        Right,
        Bottom,
        Left
    }
    // Start is called before the first frame update
    void Start()
    {
        // Calculating number of rooms that should be generated
        RoomsToCreate = Random.Range(0, 2) + 5 + level * 2;
        
        //GenerateRoomSpawnPoints();
        Vector2 roomSpawnPointPosition = Vector2.zero;
        GameObject roomSpawnPoint = Instantiate(roomSpawnPointPrefab, roomSpawnPointPosition, Quaternion.identity);
        roomSpawnPoint.GetComponent<RoomSpawnPoint>().roomsToCreate = this.RoomsToCreate;
        roomSpawnPoint.GetComponent<RoomSpawnPoint>().currentNumberOfRooms = this.CurrentNumberOfRooms;
        roomSpawnPoint.GetComponent<RoomSpawnPoint>().roomSpawnPoints = this.roomSpawnPoints;
        roomSpawnPoints.Add(roomSpawnPoint);
    }
    
    private void GenerateRoomSpawnPoints()
    {
        // Generate a list of sides to generate rooms on
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
        
        Vector2 currentRoomPosition = transform.position;
        
        foreach (Side side in sidesToGenerate)
        {
            Vector2 newRoomSpawnPointPosition = CalculateNewRoomSpawnPointPosition(side, currentRoomPosition);
            GameObject roomSpawnPoint = Instantiate(roomSpawnPointPrefab, newRoomSpawnPointPosition, Quaternion.identity);
            roomSpawnPoints.Add(roomSpawnPoint);
        }
    }
    private Vector2 CalculateNewRoomSpawnPointPosition(Side side, Vector2 currentRoomPosition)
    {
        float roomSpacingX = 14.5f;
        float roomSpacingY = 8.5f;
        
        Vector2 newRoomSpawnPointPosition = Vector2.zero;
        
        switch (side)
        {
            case Side.Top:
                newRoomSpawnPointPosition = currentRoomPosition + Vector2.up * roomSpacingY;
                break;
            case Side.Right:
                newRoomSpawnPointPosition = currentRoomPosition + Vector2.right * roomSpacingX;
                break;
            case Side.Bottom:
                newRoomSpawnPointPosition = currentRoomPosition + Vector2.down * roomSpacingY;
                break;
            case Side.Left:
                newRoomSpawnPointPosition = currentRoomPosition + Vector2.left * roomSpacingX;
                break;
        }

        Debug.Log(newRoomSpawnPointPosition);
        return newRoomSpawnPointPosition;
    }
}   

