using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerStats player;
    float moveSpeed = 10f;
    float maxSpeed = 5f;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float moveSpeed = 10f * player.speedMult;
        float maxSpeed = 5f * player.speedMult;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-(moveSpeed),0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2((moveSpeed), 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.S))
        {
            print("crouch");
        }
        if (rb.velocity.x < -10f)
        {
            rb.velocity = new Vector2(-1*maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x > 10f)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed / 1.5f);
    }
}
