using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DH_BossMeleeHitboxController : MonoBehaviour
{
    public GameObject player;
    
    public float activeLifetime;
    float activeTimer;
    bool isActive;

    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            // Check if the hitbox should be destroyed based on the timer
            if (Time.time - activeTimer >= activeLifetime)
            {
                // Destroy the hitbox (or deactivate it, depending on your design)
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        activeTimer = Time.time;
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("boss attack hit");
            collider.gameObject.GetComponent<NT_PlayerControl>().DamagePlayer(attackDamage, "phys");
            print($"player took {attackDamage} damage");
            gameObject.SetActive(false);
        }
    }
}
