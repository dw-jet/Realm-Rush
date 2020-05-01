using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    
    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
