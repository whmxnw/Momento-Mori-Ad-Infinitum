using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NT_BasicProjectile : MonoBehaviour
{
    //public NT_HitboxController hitboxController;

    void Start()
    {
        Invoke("MaxLifeTime", 3f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("attack hit");
            DH_EnemyHealth enemyHealth = other.gameObject.GetComponent<DH_EnemyHealth>();
            if (enemyHealth.currentHealth != 0)
            {
                print("damage");
                enemyHealth.TakeDamage(10);
            }
            Destroy(this.gameObject);
        }
        /*else if (other.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), collider);
        }*/
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
