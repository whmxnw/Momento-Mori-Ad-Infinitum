using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DH_Boss1Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    public float detectionRange = 5f;
    public float meleeRange = 2f;
    public float meleeDamage = 10f;

    public float moveSpeed = 0.75f;
    public float minDistance = 5f;
    public float maxDistance = 15f;
    
    public float targetDistance;
    public Vector2 lastLocation;
    public int direction;

    private float lastAttackTime = 0f;
    private float attackCooldown = 2f;

    public GameObject player = null;
    public GameObject Melee1_AttackLeft;
    public GameObject Melee1_AttackRight;
    public GameObject Melee2_AttackLeft;
    public GameObject Melee2_AttackRight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //initialize player gameObject for tracking position
        if (player == null)
            player = GameObject.FindWithTag("Player");

        //initialize boss movement
        direction = -1;
        targetDistance = GetTargetDistance();
        lastLocation = new Vector2(transform.position.x, transform.position.y);
        Patrol();

    }

    // Update is called once per frame
    void Update()
    {
        //check if player is in chasing range
        
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= detectionRange)
        {
            ChasePlayer();    
        }
        
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= meleeRange && Time.time - lastAttackTime >= attackCooldown)
        {
            PauseMovement();
            MeleeAttack1();
            ResumeMovement();
        }
        else
        {
            Patrol();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject == player)
        {
            
        }

        if (collision.collider.gameObject.tag == "Turnaround")
        {
            TurnAround();
            Patrol();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    void ChasePlayer()
    {
        direction = (player.transform.position.x < transform.position.x) ? -1 : 1;

        if (direction < 0)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    float GetTargetDistance()
    {
        return Random.Range(minDistance, maxDistance);
    }

    void MeleeAttack1()
    {
        transform.Translate(Vector3.zero);

        if (direction < 0)
            Melee1_AttackLeft.SetActive(true);
        else
            Melee1_AttackRight.SetActive(true);

        lastAttackTime = Time.time;
    }

    void MeleeAttack2()
    {
        transform.Translate(Vector3.zero);

        if (direction < 0)
            Melee2_AttackLeft.SetActive(true);
        else
            Melee2_AttackRight.SetActive(true);

        lastAttackTime = Time.time;
    }

    //paces the stage in uneven intervals
    void Patrol()
    {
        if (targetDistance <= Mathf.Abs(lastLocation.x - transform.position.x))
        {
            direction = -direction;
            targetDistance = GetTargetDistance();
            lastLocation = new Vector2(transform.position.x, transform.position.y);
        }
        if (direction < 0)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void PauseMovement()
    {
        transform.Translate(Vector2.zero);
    }

    void ResumeMovement()
    {
        if (direction < 0)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void TurnAround()
    {
        direction = -direction;
        targetDistance = GetTargetDistance();
        lastLocation = new Vector2(transform.position.x, transform.position.y);
    }
}
