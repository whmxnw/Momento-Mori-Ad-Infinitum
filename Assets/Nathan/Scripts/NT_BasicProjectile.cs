using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NT_BasicProjectile : MonoBehaviour
{
    NT_PlayerStats playerStats;
    NT_WeaponController weaponController;
    float damageAmount;
    GameObject player;

    void Start()
    {
        Invoke("MaxLifeTime", 3f);
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
        weaponController = player.GetComponentInChildren<NT_WeaponController>();
        //damageAmount = playerStats.weaponSlots[weaponController.whichWeaponSlot].damage;
        damageAmount = playerStats.weaponSlots[weaponController.whichWeaponSlot].GetComponent<NT_WeaponItem>().damage;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DH_EnemyHealth enemyHealth = other.gameObject.GetComponent<DH_EnemyHealth>();
            DH_EnemyController enemyController = other.gameObject.GetComponent<DH_EnemyController>();
            if (enemyHealth.currentHealth != 0)
            {
                //enemyController.IsStunned(this.gameObject.GetComponent<Rigidbody2D>().velocity * .01f);
                enemyHealth.TakeDamage(10);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            DH_Boss1Health enemyHealth = other.gameObject.GetComponent<DH_Boss1Health>();
            DH_Boss1Controller enemyController = other.gameObject.GetComponent<DH_Boss1Controller>();
            Rigidbody2D bossRB = other.gameObject.GetComponent<Rigidbody2D>();
            if (enemyHealth.currentHealth != 0)
            {
                bossRB.AddForce((this.gameObject.GetComponent<Rigidbody2D>().velocity * -.01f), ForceMode2D.Impulse);
                enemyHealth.TakeDamage(damageAmount);
            }
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void MaxLifeTime()
    {
        Destroy(this.gameObject);
    }
}