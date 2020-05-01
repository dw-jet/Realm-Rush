using System.Collections;
using System.IO;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Pathfinder pathfinder;
    
    void Start()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
        StartCoroutine(FollowPath());
    }

    
    IEnumerator FollowPath()
    {
        foreach (var waypoint in pathfinder.GetPath())
        {
            var enemyPos = waypoint.transform.position;
            transform.position = enemyPos;
            yield return new WaitForSeconds(1f);
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
