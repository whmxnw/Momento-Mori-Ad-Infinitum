using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UIElements;

public class CF_RoomParameters : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCleared = false;
    public bool isActive = false;
    public int enemyCount = 0;
    BoxCollider2D nTrigger;
    BoxCollider2D sTrigger;
    BoxCollider2D eTrigger;
    BoxCollider2D wTrigger;

    // touching any of these triggers should transform camera 
    // + player to correct position and activate room

    void Start()
    {
        nTrigger = GetComponent<BoxCollider2D>();
        sTrigger = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(enemyCount == 0 && !isCleared)
                clearRoom();
        }
    }

    void activateRoom()
    {
        isActive = true;
        if(isCleared)
        {
            //code to spawn enemies, lock doors
        }
        else
        {
            //code to unlock doors
        }
    }

    void deactiveRoom()
    {
        isActive = false;
        //shuts doors when player is outside of the room
    }

    void clearRoom()
    {
        isCleared = true;
        //code to spawn room clear reward
    }
}
