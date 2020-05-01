using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hitPoints = 3;
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

    private void OnParticleCollision(GameObject other)
    {
        hitPoints -= 1;
        if (hitPoints < 1)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
