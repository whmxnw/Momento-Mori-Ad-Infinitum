using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemyHealth : MonoBehaviour
{
    public float maxHealth = 40;
    public float currentHealth = 40;

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

}
