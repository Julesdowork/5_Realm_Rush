using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        audioSource.PlayOneShot(enemyHitSFX);
    }

    void KillEnemy()
    {
        var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathFX.Play();
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        //Debug.Break();
        
        Destroy(deathFX.gameObject, deathFX.main.duration);
        Destroy(gameObject);
    }
}
