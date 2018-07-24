﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // ok as this is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    [SerializeField] Color exploredColor;

    const int gridSize = 10;
    //Vector2Int gridPos;

    void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Up Face").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
