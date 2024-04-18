using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_CameraController : MonoBehaviour
{

    public static CF_CameraController instance;

    public CF_Room currRoom;

    public float moveSpeedWhenRoomChange;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (currRoom == null)
        {
            return;
        }
        Vector3 targetPos = GetCameraTargetPosition();
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime*moveSpeedWhenRoomChange);
    }

    Vector3 GetCameraTargetPosition()
    {
        if(currRoom == null)
        {
            return Vector3.zero;
        }
    Vector3 targetPos = currRoom.GetRoomCenter();
    targetPos.z=transform.position.z;
    return targetPos;

    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}
