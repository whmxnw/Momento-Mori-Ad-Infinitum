using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_Room : MonoBehaviour
{
    public int Width;
    public int Height;

    public int X;
    
    public int Y;

    //public DH_EnemySpawnController spawner;

    public CF_DungeonDoor leftDoor;
    public CF_DungeonDoor rightDoor;
    public CF_DungeonDoor topDoor;
    public CF_DungeonDoor bottomDoor;

    public List<CF_DungeonDoor> doors = new List<CF_DungeonDoor>();
    
    // Start is called before the first frame update


    void Start()
    {
        if(CF_RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene :(");
            return;
        }

        CF_DungeonDoor[] ds = GetComponentsInChildren<CF_DungeonDoor>();
        foreach(CF_DungeonDoor d in ds)
        {
            doors.Add(d);
            switch(d.doorType)
            {
                case CF_DungeonDoor.DoorType.right:
                rightDoor = d;
                break;
                case CF_DungeonDoor.DoorType.left:
                leftDoor = d;
                break;
                case CF_DungeonDoor.DoorType.top:
                topDoor = d;
                break;
                case CF_DungeonDoor.DoorType.bottom:
                bottomDoor = d;
                break;
            }
        }


        CF_RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(CF_DungeonDoor door in doors)
        {
            switch(door.doorType)
            {
                case CF_DungeonDoor.DoorType.right:
                    if(GetRight() == null)
                        door.gameObject.SetActive(false);
                break;
                case CF_DungeonDoor.DoorType.left:
                    if(GetLeft() == null)
                        door.gameObject.SetActive(false);
                break;
                case CF_DungeonDoor.DoorType.top:
                    if(GetTop() == null)
                        door.gameObject.SetActive(false);
                break;
                case CF_DungeonDoor.DoorType.bottom:
                    if(GetBottom() == null)
                        door.gameObject.SetActive(false);
                break;
            }
        }
    }

    public CF_Room GetRight()
    {
        if(CF_RoomController.instance.DoesRoomExist(X+1,Y))
        {
            return CF_RoomController.instance.FindRoom(X+1,Y);
        }
        return null;
    }

    public CF_Room GetLeft()
    {
        if(CF_RoomController.instance.DoesRoomExist(X-1,Y))
        {
            return CF_RoomController.instance.FindRoom(X-1,Y);
        }
        return null;
    }

    public CF_Room GetTop()
    {
        if(CF_RoomController.instance.DoesRoomExist(X,Y+1))
        {
            return CF_RoomController.instance.FindRoom(X,Y+1);
        }
        return null;
    }

    public CF_Room GetBottom()
    {
        if(CF_RoomController.instance.DoesRoomExist(X,Y-1))
        {
            return CF_RoomController.instance.FindRoom(X,Y-1);
        }
        return null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,new Vector3(Width, Height, 0));
    }

    public Vector2 GetRoomCenter()
    {
        return new Vector2(X*Width, Y*Height);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CF_RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
