using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth = 5;
    
    private void OnCollisionEnter(Collision other)
    {
        currentHealth -= 1;
        print("Kaboom motherfucker.");
        if (currentHealth < 1)
        {
            print("You dead bitch.");
        }
    }
}
