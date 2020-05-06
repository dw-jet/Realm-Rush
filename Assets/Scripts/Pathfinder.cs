using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint start;
    [SerializeField] private Waypoint end;
    
    private bool isRunning = true;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();
    
    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    private void FormPath()
    {
        path.Add(end);
        var next = end.exploredFrom;
        while (next != start)
        {
            path.Add(next);
            next = next.exploredFrom;
        }
        path.Add(start);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(start);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions)
        {
            var neighborCoordinates = direction + searchCenter.GetGridCoords();
            if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        var neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor)) return;
        queue.Enqueue(neighbor);
        neighbor.exploredFrom = searchCenter;
    }

    private void ColorStartAndEnd()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
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
            else
            {
                grid.Add(waypoint.GetGridCoords(), waypoint);
            }
        }

        print("Loaded " + waypoints.Length + " blocks");
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        FormPath();
    }
}
