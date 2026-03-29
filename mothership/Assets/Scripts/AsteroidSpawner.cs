using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    
    public GameObject[] asteroidObjects;

    public int amountOfAsteroids = 50;

    public float minRandomSpawn = -500;
    public float maxRandomSpawn = 500;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            
            GameObject tempObject = Instantiate(asteroidObjects[0], randomSpawnPoint, Quaternion.identity);
            //scene hierarchy will be cleaner if the asteroids are children of the spawner
            tempObject.transform.parent = this.transform;
        }
    }
    
    // see the spawn area in the scene
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxRandomSpawn * 2, maxRandomSpawn * 2, maxRandomSpawn * 2));
    }
}
