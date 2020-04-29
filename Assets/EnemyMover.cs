using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patron");
        foreach (var waypoint in path)
        {
            var enemyPos = waypoint.transform.position;
            print("Visiting block: " + waypoint.name);
            enemyPos.y = 10;
            enemyPos.z += 5;
            transform.position = enemyPos;
            yield return new WaitForSeconds(1f);
        }

        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
