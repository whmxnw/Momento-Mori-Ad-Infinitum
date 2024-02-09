using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedX;
    public float speedY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speedX, speedY);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<DH_EnemyHealth>().TakeDamage(1);
    }
}
