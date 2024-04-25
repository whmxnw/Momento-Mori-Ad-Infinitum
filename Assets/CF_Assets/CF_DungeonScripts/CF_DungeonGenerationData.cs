using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CF_DungeonGenerationData.asset", menuName = "CF_DungeonGenerationData/DungeonData")]
public class CF_DungeonGenerationData : ScriptableObject
{
    // Start is called before the first frame update

    public int numberOfCrawlers;

    public int iterationMax;

    public int iterationMin;

}
