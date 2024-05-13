using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_Boss1Health : MonoBehaviour
{
    public float maxHealth = 500;
    public float currentHealth = 500;

    // Start is called before the first frame update
    void Start()
    {
        if (currentHealth != maxHealth)
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
