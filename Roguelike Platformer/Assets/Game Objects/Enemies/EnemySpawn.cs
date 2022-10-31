using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemy;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void SpawnObject()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
