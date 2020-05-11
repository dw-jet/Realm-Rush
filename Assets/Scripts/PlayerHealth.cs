using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth = 5;
    [SerializeField] private Text healthText;

    private void Start()
    {
        healthText.text = $"Base Integrity: {currentHealth}";
    }


    private void OnTriggerEnter(Collider other)
    {
        currentHealth -= 1;
        healthText.text = $"Base Integrity: {currentHealth}";
        if (currentHealth < 1)
        {
            print("You dead bitch.");
            Destroy(gameObject);
        }
    }
}
