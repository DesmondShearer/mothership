using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    
    public GameObject[] asteroidObjects;

    public int amountOfAsteroids = 50;

    public float minRandomSpawn = -500;
    public float maxRandomSpawn = 500;
    
    void Start()
    {
        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {
        for (int i = 0; i < amountOfAsteroids; i++) {

            float randomX = Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomY = Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomZ = Random.Range(minRandomSpawn, maxRandomSpawn);
            
            Vector3 randomSpawnPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);
            
            int randomIndex = Random.Range(0, asteroidObjects.Length);
            GameObject tempObject = Instantiate(asteroidObjects[randomIndex], randomSpawnPoint, Quaternion.identity);
            tempObject.transform.parent = this.transform;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxRandomSpawn * 2, maxRandomSpawn * 2, maxRandomSpawn * 2));
    }
}
