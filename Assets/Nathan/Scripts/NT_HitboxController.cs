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
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
        weaponController = player.GetComponentInChildren<NT_WeaponController>();
        //damageAmount = playerStats.weaponSlots[weaponController.whichWeaponSlot].damage;
        damageAmount = playerStats.weaponSlots[weaponController.whichWeaponSlot].GetComponent<NT_WeaponItem>().damage;
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
            DH_EnemyHealth enemyHealth = other.gameObject.GetComponent<DH_EnemyHealth>();
            DH_EnemyController enemyController = other.gameObject.GetComponent<DH_EnemyController>();
            if (enemyHealth.currentHealth != 0)
            {
                if(player.transform.rotation.y != 0)
                {
                    enemyController.IsStunned(new Vector2(-7f, 3f));
                }
                    
                else
                {
                    enemyController.IsStunned(new Vector2(7f, 3f));
                }
                enemyHealth.TakeDamage(damageAmount);
            }

            AttackDirection.SetActive(false);
        }
        if (other.CompareTag("Boss"))
        {
            print("attack hit");
            DH_Boss1Health enemyHealth = other.gameObject.GetComponent<DH_Boss1Health>();
            DH_Boss1Controller enemyController = other.gameObject.GetComponent<DH_Boss1Controller>();
            Rigidbody2D bossRB = other.gameObject.GetComponent<Rigidbody2D>();
            if (enemyHealth.currentHealth != 0)
            {
                bossRB.velocity = new Vector2(0, 0);
                if (player.transform.rotation.y != 0)
                    bossRB.AddForce(new Vector2(-7f, 3f), ForceMode2D.Impulse);
                else
                {
                    bossRB.AddForce(new Vector2(7f, 3f), ForceMode2D.Impulse);
                }
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
