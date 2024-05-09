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
    public float moveSpeed = 3f;

    public int attackDamage = 10;
    private float lastAttackTime = 0f;
    private float attackCooldown = 2f;

    //Initial values
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetStartingDirection();
    }
    
    void Update()
    {
        if (direction < 0)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }

    //handle collisions as needed
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "Player")
        {
            CollisionAttack(collision.collider.gameObject);
        }

        if (collision.collider.gameObject.tag == "Turnaround")
        {
            ChangeDirection();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
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
