using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //put death animation method(s) here

            Destroy(gameObject);
        }
    }
}
