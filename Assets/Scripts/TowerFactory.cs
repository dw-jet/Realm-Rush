using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Transform towerParent;
    
    public Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var tower = Instantiate(towerPrefab, baseWaypoint.transform);
        tower.transform.parent = towerParent;
        towers.Enqueue(tower);
        baseWaypoint.isPlaceable = false;
        tower.baseWaypoint = baseWaypoint;
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        Tower tower = towers.Dequeue();
        tower.baseWaypoint.isPlaceable = true;
        tower.baseWaypoint = baseWaypoint;
        tower.baseWaypoint.isPlaceable = false;
        tower.gameObject.transform.position = baseWaypoint.transform.position;
        towers.Enqueue(tower);
    }
}
