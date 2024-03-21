using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CF_DoorCollision : MonoBehaviour
{
    bool isLocked = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isLocked==false)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("deactivated door");
                Renderer r = gameObject.GetComponent<Renderer>();
                r.enabled = false;
                Collider2D c = gameObject.GetComponent<Collider2D>();
                c.isTrigger = true;
            }
        }
        
    }
    
    void OnCollisionExit2D(Collision2D  collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("activated door");
            Renderer r = gameObject.GetComponent<Renderer>();
            r.enabled = true;
            Collider2D c = gameObject.GetComponent<Collider2D>();
            c.isTrigger = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
