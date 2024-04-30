using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_DungeonDoor : MonoBehaviour
{
    // Start is called before the first frame update
    
    public enum DoorType
    {
        left, right, top , bottom
    }

    public DoorType doorType;

    public GameObject doorCollider;

    private GameObject player;
    private float widthOffset = 3.5f; //may need to be changed after resizing player
    private float heightOffset = 6f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            switch(doorType)
            {
                case DoorType.bottom:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y-heightOffset);
                    break;
                case DoorType.top:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y+heightOffset);
                    break;
                case DoorType.left:
                    player.transform.position = new Vector2(transform.position.x-widthOffset, transform.position.y);
                    break;
                case DoorType.right:
                    player.transform.position = new Vector2(transform.position.x+widthOffset, transform.position.y);
                    break;
                
            }
        }
    }
}
