using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawnPoint : MonoBehaviour
{   
    public GameObject roomSpawnPointPrefab;
    public int roomsToCreate;
    public int currentNumberOfRooms;
    public List<GameObject> roomSpawnPoints;
    private enum Side
    {
        Top,
        Right,
        Bottom,
        Left
    }

    void Start()
    {
        
    }
    
    private void GenerateNeighbourRoomSpawnPoints()
    {
        if (currentNumberOfRooms == roomsToCreate)
            return;
        
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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}

