using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CF_DungeonCrawler
{

    public Vector2Int Position{get; set;}

    public CF_DungeonCrawler(Vector2Int startPos)
    {
        Position = startPos;
    }

    public Vector2Int MoveDown(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)0;
        Position += directionMovementMap[toMove];
        return Position;
    }

    public Vector2Int MoveLeft(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)1;
        Position += directionMovementMap[toMove];
        return Position;
    }
    public Vector2Int MoveRight(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)2;
        Position += directionMovementMap[toMove];
        return Position;
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
