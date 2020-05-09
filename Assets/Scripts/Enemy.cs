using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hitPoints = 3;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;

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
        hitParticlePrefab.Play();
        if (hitPoints < 1)
        {
            var dfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            dfx.Play();

            Destroy(dfx.gameObject, dfx.main.duration);
            Destroy(gameObject);
        }
    }
}
