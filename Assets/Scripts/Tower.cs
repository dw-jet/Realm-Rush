using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private float firingRange = 3.0f;
    [SerializeField] private ParticleSystem projectileParticle;

    // Update is called once per frame
    void Update()
    {
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
