using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float xRange = 48; 
    private float minZRange = -8; 
    private float maxZRange = 48; 

    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); 
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xRange, xRange); 
        float spawnPosZ = Random.Range(minZRange, maxZRange); 
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ); 
        return randomPos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
