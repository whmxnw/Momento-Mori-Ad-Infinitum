using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class NT_NewItem : MonoBehaviour
{
    
    NT_PlayerStats playerStats;
    public string itemName;
    public int maxHpAdd = 0;
    public int currentHpAdd = 0;
    public float attackMultAdd = 0;
    public float speedMultAdd = 0;
    public int dashNumAdd = 0;
    public int jumpNumAdd = 0;
    public int ArmorAdd = 0;
    public int FortitudeAdd = 0;

    float floatSpeed = 1f;
    float floatHeight = .25f;
    private Vector3 startPos;
    private bool afterStart = false;

    public bool isHovering;

    float pickupDistance = 3f;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
        startPos = transform.position;
        Invoke("Wait", 1f);
    }

    private void Update()
    {
        if (afterStart)
        {
            Vector3 newPos = startPos + Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = newPos;
        }


        if (isHovering && Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            PickUpItem();
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;
    }

    private void OnMouseExit()
    {
        isHovering = false;
    }

    private void PickUpItem()
    {
        print("pickup");
        playerStats.AddItem(maxHpAdd, currentHpAdd, attackMultAdd, speedMultAdd, dashNumAdd, jumpNumAdd, ArmorAdd, FortitudeAdd);
        Destroy(gameObject);
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, playerStats.transform.position);
        return distance <= pickupDistance;
    }

    private void Wait()
    {
        startPos = transform.position;
        print(startPos);
        afterStart = true;
    }
}
