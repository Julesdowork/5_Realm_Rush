using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;

    void Start()
    {
        healthText.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health--;
        healthText.text = health.ToString();
    }
}
