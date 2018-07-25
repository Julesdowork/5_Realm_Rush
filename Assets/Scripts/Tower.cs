using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower - don't change
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;

    // State of each tower - changes
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy(targetEnemy);
        }
        else
        {
            Shoot(false);
        }
	}

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    Transform GetClosestEnemy(Transform enemyA, Transform enemyB)
    {
        float distanceA = Vector3.Distance(transform.position, enemyA.position);
        float distanceB = Vector3.Distance(transform.position, enemyB.position);

        return distanceA <= distanceB ? enemyA : enemyB;
    }

    void FireAtEnemy(Transform enemy)
    {
        float distanceToEnemy = Vector3.Distance(enemy.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
           Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isFiring)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isFiring;
    }
}
