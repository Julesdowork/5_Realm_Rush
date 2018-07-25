using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // ok as this is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    const int gridSize = 10;
    bool hasTower;
    //Vector2Int gridPos;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))    // left-clicked
        {
            if (isPlaceable && !hasTower)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
                hasTower = true;
            }
            else if (hasTower)
            {
                print("There's already a tower here");
            }
            else
            {
                print("Can't place a tower here");
            }
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
}
