using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DH_EnemySpawnerController : MonoBehaviour
{
    public int minimumSpawns;
    public int maximumSpawns;
    public int totalSpawns;
    public GameObject enemyType;

    void Start()
    {
        Invoke("SpawnEnemies", 1f);
    }

    void SpawnEnemies()
    {
        totalSpawns = Random.Range(minimumSpawns, maximumSpawns);
        Vector3 spawnPoint = (gameObject.transform.position);
        spawnPoint.z = 0;
        for (int i = 0; i < totalSpawns; i++)
            Instantiate(enemyType, spawnPoint, new Quaternion(0, 0, 0, 0));
    }


}
