using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    private Vector2Int gridPos;
    const int gridSize = 10;
    public bool isPlaceable = true;
    [SerializeField] private Tower towerPrefab;

    private void Awake()
    {
        isPlaceable = true;
    }

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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            Instantiate(towerPrefab, gameObject.transform);
            isPlaceable = false;
        }
    }
}
