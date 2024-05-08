using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
    {
        //up = 0,
        left = 1,
        down = 0,
        right = 2
    };

public class CF_DungeonCrawlerController : MonoBehaviour
{
    public static int iterations = 0;
    // Start is called before the first frame update

    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap =  new Dictionary<Direction, Vector2Int>
    {
        //{Direction.up,Vector2Int.up},
        {Direction.left,Vector2Int.left},
        {Direction.down,Vector2Int.down},
        {Direction.right,Vector2Int.right},
    };

    public static List<Vector2Int> GenerateDungeon(CF_DungeonGenerationData dungeonData)
    {
        List<CF_DungeonCrawler> dungeonCrawlers = new List<CF_DungeonCrawler>();
        for (int i = 0; i<dungeonData.numberOfCrawlers;i++)
        {
            dungeonCrawlers.Add(new CF_DungeonCrawler(Vector2Int.zero));
        }

        iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);
        for(int i = 0;i<iterations;i++)
        {
            foreach(CF_DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                Vector2Int newPos=dungeonCrawler.MoveDown(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }

        return positionsVisited;
    }

}
