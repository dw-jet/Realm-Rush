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
        transform.position = new Vector3(waypoint.GetGridCoords().x * gridSize, 0f, waypoint.GetGridCoords().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        var labelText = waypoint.GetGridCoords().x + ", " + waypoint.GetGridCoords().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
