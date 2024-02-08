using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NT_PlayerControl : MonoBehaviour
{
    public NT_PlayerStats player;
    float moveSpeed = 15f;
    float maxSpeed = 100f;
    Rigidbody2D rb;
    public bool isGrounded;
    int jumpsRemaining;
    float lastClickLeft;
    float lastClickRight;
    float doubleTapTimer = .1f;
    bool isDashing = false;
    bool inDash = false;
    float dashSpeed = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float moveSpeed = 10f * player.speedMult;
        float maxSpeed = 20f * player.speedMult;
        float dashSpeed = 200f * player.speedMult;

        if(inDash)
        {
            rb.drag = 0;
        }

        if (Input.GetKey(KeyCode.A) & !inDash) //left movement
        {
            rb.drag = 0;
            
            rb.AddForce(new Vector2(-(moveSpeed),0));
        }
        if (Input.GetKeyUp(KeyCode.A) && isGrounded) //resetting friction
        {
            rb.drag = 100;
        }
        if (Input.GetKeyUp(KeyCode.A)) //setting up for double click timer
        {
            lastClickLeft = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.A))  //overriding momentum
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) & !inDash) //right movement
        {
            rb.drag = 0;
            rb.AddForce(new Vector2((moveSpeed), 0));
        }
        if (Input.GetKeyUp(KeyCode.D) && isGrounded)  //resetting friction
        {
            rb.drag = 100;
        }
        if (Input.GetKeyUp(KeyCode.D)) //setting up for double click timer
        {
            lastClickRight = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.D))  //overiding momentum 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))    //crouch input if we ever use it for anything other than dropping through platforms
        {
            print("crouch");
        }
        if (rb.velocity.x < (-1 * maxSpeed))    //locking maxspeed
        {
            rb.velocity = new Vector2(-1*maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x > maxSpeed)   //locking maxspeed for other direction
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)   //jump input that checks max number of jumps
        {
            rb.drag = 0;
            Jump();
        }
        
        //dash input timers
        if(Input.GetKeyDown(KeyCode.A))
        {
            if ((Time.time - lastClickLeft) < doubleTapTimer) {
                if (!isDashing)
                {
                    rb.drag = 0;
                    Dash(Vector2.left);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if ((Time.time - lastClickRight) < doubleTapTimer) {
                if (!isDashing)
                {
                    rb.drag = 0;
                    Dash(Vector2.right);
                }
            }
        }
    }

    //dashing stuff
    void Dash(Vector2 direction)
    {
        isDashing = true;
        inDash = true;
        print("dash");
        rb.velocity = new Vector2(0, 0); // Reset velocity before dashing
        rb.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        StartCoroutine(ResetDash());
        StartCoroutine(InDash());
    }
    IEnumerator ResetDash() //recharge time for dash
    {
        yield return new WaitForSeconds(2f);
        isDashing = false;
    }

    IEnumerator InDash() //bool check for when the player is dashing
    {
        yield return new WaitForSeconds(.15f);
        inDash = false;
        rb.velocity = new Vector2(rb.velocity.x * .5f, rb.velocity.y);
        if (isGrounded) {
            rb.drag = 100;
        }
        
    }

    //jumping stuff
    void OnCollisionEnter2D(Collision2D collision) //checking if touching floor
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            rb.drag = 100;
            jumpsRemaining = player.jumpNum; //resetting remaining jumps when touching floor
        }
    }
    void OnCollisionExit2D(Collision2D collision)   //noting player is airborne
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    void Jump() //current jumping physics, scales off of movespeed, might change to static amount
    {
        print("jump");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * (moveSpeed / 1.75f), ForceMode2D.Impulse);
        jumpsRemaining--;
    }
}
