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

    public GameObject player = null;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is in chasing range
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= detectionRange)
            if(Mathf.Abs(player.transform.position.x - transform.position.x) <= meleeRange)
                //melee attack
            else 
                //chase player

        if (targetDistance <= Mathf.Abs(lastLocation.x - transform.position.x))
            TurnAround();

        if (direction < 0)
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject == player)
        {
            
        }

        if (collision.collider.gameObject.tag == "Enemy" || collision.collider.gameObject.tag == "Turnaround")
        {
            TurnAround();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    void TurnAround()
    {
        direction = -direction;
        targetDistance = GetTargetDistance();
        lastLocation = new Vector2(transform.position.x, transform.position.y);
    }

    float GetTargetDistance()
    {
        return Random.Range(minDistance, maxDistance);
    }

    void FollowPlayer()
    {

    }
}
