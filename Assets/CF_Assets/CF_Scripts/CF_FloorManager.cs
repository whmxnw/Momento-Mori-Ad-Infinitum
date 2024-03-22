using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_FloorManager : MonoBehaviour
{
    public static CF_FloorManager Instance;
    public int enemyCount = 2;
    //public CF_RoomParameters[] rooms;
    public static event Action<int> SetActiveRoom;
    public static event Action<int> SetInactiveRoom;

    [SerializeField] private int roomToActivate;
    [SerializeField] private int roomtoDeactivate;

    private void Awake()
    {
        Instance = this;
    }
    
    public void changeActive()
    {
        SetActiveRoom?.Invoke(roomToActivate);
        Debug.Log("setActive");
    }

    public void changeInactive()
    {
        SetInactiveRoom?.Invoke(roomtoDeactivate);
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
