using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] private float secondsBetweenSpawns = 2f;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Text scoreText;

    private int score = 0;
    void Start()
    {
        scoreText.text = $"Score: {score}";
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var enemey = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 90, 0));
            enemey.transform.parent = enemyParent;
            score += 1;
            scoreText.text = $"Score: {score}";
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
 