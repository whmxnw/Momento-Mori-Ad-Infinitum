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

    public float fallSpeed = -1f;
    public float walkingSpeed = 3f;

    public int attackDamage = 10;

    //Initial values
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

    //handle collisions as needed
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "Player")
        {
            CollisionAttack(collision.collider.gameObject);
        }

        if (collision.collider.gameObject.tag == "Enemy" || collision.collider.gameObject.tag == "Turnaround")
        {
            ChangeDirection();
            velocity = new Vector2(walkingSpeed * direction, 0);
            rb.velocity = velocity;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    //handle triggers as needed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Turnaround")
        {
            ChangeDirection();
            velocity = new Vector2(walkingSpeed * direction, 0);
            rb.velocity = velocity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    //flip enemy x-direction
    private void ChangeDirection()
    {
        direction *= -1;
    }


    //attack player upon collision
    public void CollisionAttack(GameObject target)
    {
        target.GetComponent<NT_PlayerControl>().DamagePlayer(attackDamage, "phys");
    }


    //perform knockback effect on player when certain attacks are performed
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
