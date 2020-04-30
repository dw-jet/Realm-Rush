using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridCoords()))
            {
                Debug.LogWarning("Overlapping block" + waypoint);
            }
            grid.Add(waypoint.GetGridCoords(), waypoint);
        }

        print("Loaded " + waypoints.Length + " blocks");
    }
}
