using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public int minimumSpawns;
    public int maximumSpawns;
    public GameObject enemyType;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int spawnCount = Random.Range(minimumSpawns, maximumSpawns);
        Vector3 spawnPoint = (gameObject.transform.position);
        spawnPoint.z = 0;
        for (int i = 0; i < spawnCount; i++)
            Instantiate(enemyType, spawnPoint, new Quaternion(0, 0, 0, 0));
    }


}
