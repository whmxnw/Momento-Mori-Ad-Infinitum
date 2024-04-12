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

    public bool isHovering;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NT_PlayerStats>();
    }
    private void Update()
    {
        if (isHovering && Input.GetKeyDown(KeyCode.E))
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
}
