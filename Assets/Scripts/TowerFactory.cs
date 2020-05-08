using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private int towerLimit = 5;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (FindObjectsOfType<Tower>().Length < towerLimit)
        {
            Instantiate(towerPrefab, baseWaypoint.transform);
            baseWaypoint.isPlaceable = false;
        }
        else
        {
            print("You have too many towers.");
        }
    }
}
