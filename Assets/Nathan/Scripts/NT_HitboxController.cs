using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NT_HitboxController : MonoBehaviour
{
    NT_PlayerStats playerStats;
    NT_WeaponController weaponController;
    float damageAmount;
    public GameObject AttackDirection;
    float lifetime = 0.15f; // Adjust the lifetime as needed
    private float timer;
    bool isActive;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
        weaponController = player.GetComponentInChildren<NT_WeaponController>();
        damageAmount = playerStats.weaponSlots[weaponController.whichWeaponSlot].damage;
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
            DH_EnemyHealth enemyHealth = other.gameObject.GetComponent<DH_EnemyHealth>();
            if (enemyHealth.currentHealth != 0)
            {
                print("damage");
                enemyHealth.TakeDamage(damageAmount);
            }

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
