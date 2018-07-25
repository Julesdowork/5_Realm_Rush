using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticle.Play();
    }

    void KillEnemy()
    {
        var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathFX.Play();
        Destroy(gameObject);
    }
}
