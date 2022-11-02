using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject prefabObject;

    public Transform[] spawnPoints;
    public GameObject enemy;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;


    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update()
    {
            
    }

    public void SpawnObject()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        
        Selection.activeObject = PrefabUtility.InstantiatePrefab(prefabObject, transform);
        var tempPrefab = Selection.activeGameObject;
        tempPrefab.transform.position = spawnPoints[randSpawnPoint].position;
        tempPrefab.transform.rotation = transform.rotation;
    }

}
