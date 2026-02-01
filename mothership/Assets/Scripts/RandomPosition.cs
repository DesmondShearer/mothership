using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    
    private Rigidbody asteroidRb;

    private float xMax = 200.0f; //max position of asteroid on +ve x-axis
    private float xMin = -200.0f; //max position of asteroid on -ve x-axis

    private float yMax = 200.0f; //max position of asteroid on +ve y-axis
    private float yMin = -200.0f; //max position of asteroid on -ve y-axis

    private float zMax = 200.0f; //max position of asteroid on +ve z-axis
    private float zMin = -200.0f; //max position of asteroid on -ve z-axis

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.transform.position = RandomSpawnPosition();      
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
    }
}
