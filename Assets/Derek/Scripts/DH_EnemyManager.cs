using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DH_EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(2);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("DamageEnemyTimer");
    }

    void SpawnEnemy(float x)
    {
        float y = 0.25f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 0));
        spawnPoint.z = 0;
        GameObject.Instantiate(enemy, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    public void SpawnEnemies(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            SpawnEnemy(Random.Range(0.3f, 0.6f));
        }
    }
}
