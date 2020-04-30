using System;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridCoords().x, 0f, waypoint.GetGridCoords().y);
    }

    private void UpdateLabel()
    {
        var gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        var labelText = waypoint.GetGridCoords().x/gridSize + ", " + waypoint.GetGridCoords().y/gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
