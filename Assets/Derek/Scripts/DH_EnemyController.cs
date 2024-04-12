using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DH_EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    public int direction;
    public Vector2 velocity;

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
        Debug.Log(direction);
        grounded = true;
        velocity = new Vector2(walkingSpeed * direction, 0);
        rb.velocity = velocity;
    }
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Turnaround")
        {
            ChangeDirection();
            velocity = new Vector2(walkingSpeed * direction, 0);
            rb.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.collider.gameObject.tag == "Player")
        {
            CollisionAttack(collision);
        }

        if (collision.collider.gameObject.layer == 7)
        {
            ChangeDirection();
            velocity = new Vector2(walkingSpeed * direction, 0);
            rb.velocity = velocity;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    private void ChangeDirection()
    {
        direction *= -1;
    }


    private void CollisionAttack(Collision2D collision)
    {
        collision.collider.gameObject.GetComponent<NT_PlayerControl>().DamagePlayer(attackDamage, "phys");
    }


    //performs knockback effect on player when certain attacks are performed
    private void KnockbackObject(GameObject player)
    {
        Rigidbody2D player_rb = player.GetComponent<Rigidbody2D>();

        //how hard enemy will be knocked back
        float kbForce = 4f;

        //determine direction which to send enemy
        Vector2 kbDirection = (player.transform.position - transform.position).normalized;

        //kill player's momentum before applying force
        player_rb.velocity = Vector2.zero;

        //apply knockback to player
        player_rb.AddForce(kbForce * kbDirection, ForceMode2D.Impulse);
    }


    private void GetStartingDirection()
    {
        int x = Random.Range(0, 50);

        if (x % 2 == 0)
            direction = 1;
        else
            direction = -1;
    }


}
