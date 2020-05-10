using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth = 5;
    

    private void OnTriggerEnter(Collider other)
    {
        currentHealth -= 1;
        if (currentHealth < 1)
        {
            print("You dead bitch.");
            Destroy(gameObject);
        }
    }
}
