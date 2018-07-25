using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemy;

	// Use this for initialization
	void Start()
    {
        StartCoroutine(SpawnEnemy());
	}

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
