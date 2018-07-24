using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;
	
	// Update is called once per frame
	void Update()
    {
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
