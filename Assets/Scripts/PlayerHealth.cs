using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;

    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        health--;
    }
}
