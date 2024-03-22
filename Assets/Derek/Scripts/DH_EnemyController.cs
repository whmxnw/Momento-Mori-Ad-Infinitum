using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DH_EnemyController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public static int direction;

    public bool grounded;
    public bool chasesEnemy;
    public bool avoidsFalling;

    public float fallSpeed = -1f;
    public float walkingSpeed = 3f;

    public int attackDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GetStartingDirection();
        grounded = true;
        //rb.velocity = new Vector2(walkingSpeed * direction, 0);

    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).x < 0.1 || Camera.main.WorldToViewportPoint(transform.position).x > 0.9)
        {
            ChangeDirection();
            rb.velocity = new Vector2(walkingSpeed * direction, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Floor")
        {
            grounded = true;
            fallSpeed = 0;
        }

        if (collision.collider.gameObject.tag == "Player")
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            CollisionAttack(collision);
        }
    }

        public void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.gameObject.tag == "Floor")
            {
                grounded = false;
                fallSpeed = -1;
            }
        }


        public void ChangeDirection()
        {
            direction *= -1;
        }


        public void CollisionAttack(Collision2D collision)
        {
            
            collision.collider.gameObject.GetComponent<NT_PlayerControl>().DamagePlayer(attackDamage, "phys");
            print("player damage");
           //KnockbackObject(playerRB);
        }


        //performs knockback effect on player when certain attacks are performed
        public void KnockbackObject(Rigidbody2D playerRB)
        {
            //how hard enemy will be knocked back
            float kbForce = 4f;

            //determine direction which to send enemy
            Vector2 kbDirection = (player.transform.position - transform.position).normalized;

            //kill player's momentum before applying force
            playerRB.velocity = Vector2.zero;

            //apply knockback to player
            playerRB.AddForce(kbForce * kbDirection, ForceMode2D.Impulse);
        }


        public static void GetStartingDirection()
        {
            int x = Random.Range(0, 50);

            if (x % 2 == 0)
                direction = 1;
            else
                direction = -1;
        }


        public void TakeDamage(float amount)
        {
            gameObject.GetComponent<DH_EnemyHealth>().currentHealth -= amount;

            if (gameObject.GetComponent<DH_EnemyHealth>().currentHealth <= 0)
            {
                //put death animation method(s) here

                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<DH_EnemyHealth>().currentHealth != 0)
            {
            print("damage");
            }

    }
}
