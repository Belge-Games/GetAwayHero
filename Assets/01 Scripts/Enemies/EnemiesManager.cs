using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTime;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        timer = spawnTime;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 spawnPos = GenerateRandomSpawnPosition();
            spawnPos += GameController.GetPlayer().transform.position; 

            GameObject currentObject = gameObjects[i];
            currentObject = Instantiate(currentObject);
            currentObject.transform.position = spawnPos;
            currentObject.transform.parent = transform;
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 spawnPos = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;
        if(Random.value > 0.5f)
        {
            spawnPos.x = Random.Range(-spawnArea.x, spawnArea.x);
            spawnPos.y = spawnArea.y * f;
        } 
        else 
        {
            spawnPos.y = Random.Range(-spawnArea.y, spawnArea.y);
            spawnPos.x = spawnArea.x * f;
        }

        spawnPos.z = 0f;

        return spawnPos;
    }
}
