using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NT_PlayerControl : MonoBehaviour
{
    public NT_PlayerStats player;
    float moveSpeed = 15f;
    float maxSpeed; //= 100f;
    Rigidbody2D rb;
    public bool isGrounded;
    int jumpsRemaining;
    bool isDashing = false;
    bool inDash = false;
    float dashDistance = 5f;
    private GameObject currentPlatform;
    private BoxCollider2D playerCollider; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        //WIP testing limited frame rate
        //Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;      
    }

    void Update()
    {
        moveSpeed = 1000f * player.speedMult;
        maxSpeed = 10f * player.speedMult;
        dashDistance = 3f * player.speedMult;

        if(inDash)
        {
            rb.drag = 0;
        }

        //new dash input with shift key
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && !isDashing)
        {
            rb.drag = 0;
            Vector2 dashDirection = Input.GetKey(KeyCode.A) ? Vector2.left : Vector2.right;

            Dash(dashDirection, dashDistance);
        }

        if (Input.GetKey(KeyCode.A) & !inDash) //left movement
        {
            rb.drag = 0;
            
            rb.AddForce(new Vector2(-(moveSpeed)* Time.deltaTime,0));
        }
        if (Input.GetKeyUp(KeyCode.A) && isGrounded) //resetting friction
        {
            rb.drag = 100;
        }

        if (Input.GetKeyDown(KeyCode.A))  //overriding momentum
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) & !inDash) //right movement
        {
            rb.drag = 0;
            rb.AddForce(new Vector2((moveSpeed) * Time.deltaTime, 0));
        }
        if (Input.GetKeyUp(KeyCode.D) && isGrounded)  //resetting friction
        {
            rb.drag = 100;
        }

        if (Input.GetKeyDown(KeyCode.D))  //overiding momentum 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))    //crouch input if we ever use it for anything other than dropping through platforms
        {
            //print("crouch");
            if(currentPlatform != null)
            {
                StartCoroutine(DisablePlatform());
            }
        }
        if (rb.velocity.x < (-1 * maxSpeed) /*&& !isDashing*/)    //locking maxspeed
        {
            rb.velocity = new Vector2(-1*maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x > maxSpeed /*&& !isDashing*/)   //locking maxspeed for other direction
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)   //jump input that checks max number of jumps
        {
            rb.drag = 0;
            Jump();
        }


    }

    //dashing stuff
    void Dash(Vector2 direction, float distance)
    {
        isDashing = true;
        inDash = true;
        print("dash");

        // Calculate the target position based on the current position and dash distance
        Vector2 targetPosition = rb.position + (direction * distance);

        // Perform a raycast to check for obstacles in the dash direction
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, distance, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
        {
            // Directly set the position to the collision point
            targetPosition = hit.point;
        }

        // Move the Rigidbody2D to the target position
        rb.MovePosition(targetPosition);

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
        yield return new WaitForSeconds(.1f);
        inDash = false;
        rb.velocity = new Vector2(rb.velocity.x * .5f, rb.velocity.y);
        if (isGrounded) {
            rb.drag = 100;
        }
        
    }

    //jumping stuff
    void OnCollisionStay2D(Collision2D collision) //checking if touching floor
    {
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            if(rb.velocity.y == 0) {
                isGrounded = true;
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                    rb.drag = 0;
                }
                else {rb.drag = 100;}
                jumpsRemaining = player.jumpNum; //resetting remaining jumps when touching floor
            }
        }
        if(collision.gameObject.CompareTag("Platform"))
        {
            currentPlatform = collision.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D collision)   //noting player is airborne
    {
        if(collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            rb.drag = 0;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentPlatform = null;
        }
    }

    private IEnumerator DisablePlatform()
    {
        BoxCollider2D platformCollider = currentPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    void Jump() //current jumping physics, scales off of movespeed, might change to static amount
    {
        print("jump");
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * (moveSpeed / 2.25f) * Time.deltaTime, ForceMode2D.Impulse);
        jumpsRemaining--;
    }

    //player damage
    public void DamagePlayer(float amount, string type)
    {
        if (type == "phys")
        {
            //WIP basic damage calc with armor, for direct attacks from enemies
            player.currentHp -= (int)(amount * ((100 - player.Armor) / 100));
        }
        if(type == "magic")
        {
            //WIP basic damage calc with fortitude, for magical status effects (i.e, burning)
            player.currentHp -= (int)(amount * ((100 - player.Fortitude) / 100));
        }
    }
}
