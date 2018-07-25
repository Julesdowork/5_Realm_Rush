using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemy;
    [SerializeField] Text scoreText;

    int enemyCount;

	// Use this for initialization
	void Start()
    {
        scoreText.text = enemyCount.ToString();
        StartCoroutine(SpawnEnemy());
	}

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, gameObject.transform);
            enemyCount++;
            scoreText.text = enemyCount.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
