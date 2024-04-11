using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CF_DoorCollision : MonoBehaviour
{
    bool isLocked = false;
    bool cleared = false;
    void OnCollisionStay2D(Collision2D collision)
    {
        if(isLocked==false)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if (CF_FloorManager.Instance.enemyCount <= 0)
                {
                    Debug.Log("deactivated door");
                    Renderer r = gameObject.GetComponent<Renderer>();
                    r.enabled = false;
                    Collider2D c = gameObject.GetComponent<Collider2D>();
                    c.isTrigger = true;
                    cleared = true;
                }
                
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
            EnterNewRoom();
        }
    }

    public void EnterNewRoom()
    {
        if (CF_FloorManager.Instance.enemyCount == 0)
        {
            CF_FloorManager.Instance.enemyCount = 2;
            cleared = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cleared)
        {

        }
    }
}
