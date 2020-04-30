using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
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
            Mathf.RoundToInt(pos.x / gridSize) * gridSize,
            Mathf.RoundToInt(pos.z / gridSize) * gridSize
            );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
