using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemyHealth : MonoBehaviour
{
    public float maxHealth = 40;
    public float currentHealth = 40;
    public GameObject spawner;

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
            gameObject.transform.GetComponentInParent<DH_EnemySpawnerController>().totalSpawns--;
            CF_RoomController.instance.UpdateRooms();
        }
    }
}
