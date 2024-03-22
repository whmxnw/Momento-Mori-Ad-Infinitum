﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NT_HitboxController : MonoBehaviour
{
    public float damageAmount = 10f;
    public GameObject AttackDirection;
    float lifetime = 0.5f; // Adjust the lifetime as needed
    private float timer;
    bool isActive;

    void Start()
    {
        
    }
    void Update()
    {
        if (isActive) { 
            // Check if the hitbox should be destroyed based on the timer
            if (Time.time - timer >= lifetime)
            {
                // Destroy the hitbox (or deactivate it, depending on your design)
                AttackDirection.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("attack hit");
            DH_EnemyController enemyController = other.GetComponent<DH_EnemyController>();
            enemyController.TakeDamage(damageAmount);
            AttackDirection.SetActive(false);
        }
    }

    private void OnEnable()
    {
        timer = Time.time;
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }
}
