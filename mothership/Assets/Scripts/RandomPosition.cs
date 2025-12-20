using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    
    private Rigidbody asteroidRb;

    private float xMax = 200.0f;
    private float xMin = -200.0f;

    private float yMax = 200.0f;
    private float yMin = -200.0f;
    
    private float zMax = 200.0f;
    private float zMin = -200.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.transform.position = RandomSpawnPosition();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
    }
}
