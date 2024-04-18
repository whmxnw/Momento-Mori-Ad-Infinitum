using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_Room : MonoBehaviour
{
    public int Width;
    public int Height;

    public int X;
    
    public int Y;
    // Start is called before the first frame update


    void Start()
    {
        if(CF_RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene :(");
            return;
        }

        CF_RoomController.instance.RegisterRoom(this);
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
