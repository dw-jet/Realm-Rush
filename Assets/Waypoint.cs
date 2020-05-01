using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    private Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridCoords()
    {
        var pos = transform.position;
        return new Vector2Int(
            Mathf.RoundToInt(pos.x / gridSize),
            Mathf.RoundToInt(pos.z / gridSize)
            );
    }

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

}
