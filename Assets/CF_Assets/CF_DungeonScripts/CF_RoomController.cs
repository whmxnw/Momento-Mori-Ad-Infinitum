using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    public string name;
    public int X;
    public int Y;

}

public class CF_RoomController : MonoBehaviour
{
    public static CF_RoomController instance;

    string currentWorldName = "CF_Stage1";

    RoomInfo currentLoadRoomData;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<CF_Room> loadedRooms = new List<CF_Room>();

    bool isLoadingRoom = false;

    CF_Room currRoom;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadRoom("Start",0,0);
        LoadRoom("Start",0,-1);
        LoadRoom("Start",0,-2);
    }

    void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue()
    {
        if(isLoadingRoom)
        {
            return;
        }

        if(loadRoomQueue.Count == 0)
        {
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    public void LoadRoom(string name, int x, int y)
    {
        if(DoesRoomExist(x,y))
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(CF_Room room)
    {
        room.transform.position = new Vector2(currentLoadRoomData.X*room.Width,currentLoadRoomData.Y*room.Height);
        room.X = currentLoadRoomData.X;
        room.Y = currentLoadRoomData.Y;
        room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + " , " + room.Y;
        room.transform.parent = transform;

        isLoadingRoom = false;

        if(loadedRooms.Count == 0)
        {
            CF_CameraController.instance.currRoom = room;
        }

        loadedRooms.Add(room);
    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find( item => item.X == x && item.Y == y ) != null;
    } 

    public void OnPlayerEnterRoom(CF_Room room)
    {
        CF_CameraController.instance.currRoom = room;
        currRoom = room;
    }
}
