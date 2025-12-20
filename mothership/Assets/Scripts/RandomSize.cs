using UnityEngine;

public class RandomSize : MonoBehaviour
{
    private Rigidbody asteroidRb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();

        float randomRange = Random.Range(10.0f, 25.0f);
        Vector3 randomScale = new Vector3(randomRange, randomRange, randomRange);
        asteroidRb.transform.localScale = randomScale;
        asteroidRb.mass = randomRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
