using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_DungeonGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public CF_DungeonGenerationData dungeonGenerationData;

    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = CF_DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        CF_RoomController.instance.LoadRoom("Start",0,0); 
        foreach(Vector2Int roomLocation in rooms)
        {
            CF_RoomController.instance.LoadRoom("Start",roomLocation.x,roomLocation.y); //to be replaced with random room from list
        }
        int itemRoomSpawn = Random.Range(1,CF_DungeonCrawlerController.iterations-1);
        CF_RoomController.instance.LoadRoom("Start",1,-1*itemRoomSpawn);    //to be replaced with item room
        int shopRoomSpawn = Random.Range(1,CF_DungeonCrawlerController.iterations-1);
        CF_RoomController.instance.LoadRoom("Start",-1,-1*shopRoomSpawn); //to be replaced with shop room
        int bossRoomSpawn = CF_DungeonCrawlerController.iterations+1;
        CF_RoomController.instance.LoadRoom("Start",0,-1*bossRoomSpawn);  // to be replaced with boss room spawn
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
