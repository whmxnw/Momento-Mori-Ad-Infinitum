using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CF_RoomParameters : MonoBehaviour
{
    [SerializeField] private int roomNumber;

    public bool isCleared = false;
    public bool isActive = true;
    public int enemyCount = 0;
    public BoxCollider2D sTrigger;

    private void Awake()
    {
        CF_FloorManager.SetActiveRoom += activateRoom;
        CF_FloorManager.SetInactiveRoom += deactivateRoom;
    }

    void Start()
    {
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
        else if(isActive == false)
        {
            Debug.Log("Deactivated");
        }
    }

    void activateRoom(int roomToActivate)
    {
        if(roomToActivate == roomNumber)
        {
            isActive = true;
            if (isCleared)
            {
                //code to spawn enemies, lock doors
            }
            else
            {
                //code to unlock doors
            }
        }
    }

    void deactivateRoom(int roomToDeactivate)
    {
        if(roomToDeactivate == roomNumber)
        {
            isActive = false;
            //shuts doors when player is outside of the room
        }

    }

    void clearRoom()
    {
        isCleared = true;
        //code to spawn room clear reward
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            CF_FloorManager.Instance.changeActive();
        }
    }
}
