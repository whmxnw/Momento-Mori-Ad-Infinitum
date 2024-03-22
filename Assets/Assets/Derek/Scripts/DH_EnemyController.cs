using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DH_EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int direction;

    public bool grounded;
    public bool chasesEnemy;
    public bool avoidsFalling;

    public float fallSpeed = -1f;
    public float walkingSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        GetStartingDirection();
        grounded = true;
        rb.velocity = new Vector2(walkingSpeed * direction, 0);

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

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.gameObject.tag == "Floor")
        {
            grounded = true;
            fallSpeed = 0;
        }

        if (collision.collider.gameObject.tag == "Player")
        {
            CollisionAttack(collision.collider.gameObject);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    private void ChangeDirection()
    {
        direction *= -1;
    }


    private void CollisionAttack(GameObject player)
    { 
        player.GetComponent<NT_PlayerStats>().currentHp -= 5;
        KnockbackObject(player);
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
