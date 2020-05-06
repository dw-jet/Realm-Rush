using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform objectToPan;
    [SerializeField] private float firingRange = 3.0f;
    [SerializeField] private ParticleSystem projectileParticle;

    private Transform targetEnemy;
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (var testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var towerPos = gameObject.transform.position;
        var distanceToClosest = Vector3.Distance(towerPos, transformA.position);
        var distanceToTest = Vector3.Distance(towerPos, transformB.position);
        
        if (distanceToClosest < distanceToTest)
        {
            return transformA;
        }
        
        return transformB;
    }

    private void FireAtEnemy()
    {
        var distanceToEnemy = Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position);
        Shoot(distanceToEnemy <= firingRange);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
