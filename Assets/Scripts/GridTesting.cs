using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{

    private MovementGrid<TestingGridObject> grid;
    
    
    private void Start()
    {
        grid = new MovementGrid<TestingGridObject>(18, 5, 5f, new Vector2(-45, -16), () => new TestingGridObject());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //grid.SetValue(GetMouseWorldPosition(), 56);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetGridObject(GetMouseWorldPosition()));
        }
    }

    private static Vector2 GetMouseWorldPosition()
    {
        Vector2 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        return vec;
    }

    private static Vector2 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector2 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}


public class TestingGridObject
{
    public int value;

    public void AddValue(int addValue)
    {
        value += addValue;
    }
}