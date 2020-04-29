using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField][Range(1, 20)] private int gridSize = 10;
    private TextMesh textMesh;
    void Update()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        Vector3 snapPos;
        var pos = transform.position;
        snapPos.x = Mathf.RoundToInt(pos.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(pos.z / gridSize) * gridSize;
        transform.position = snapPos;
        PrintLabel(snapPos.x, snapPos.z);
    }

    private void PrintLabel(float x, float y)
    {
        textMesh.text = x/gridSize + ", " + y/gridSize;
    }

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }
}
