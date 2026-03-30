using UnityEngine;

public class RandomSize : MonoBehaviour
{
    private Rigidbody asteroidRb;
    
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();

        float randomRange = Random.Range(10.0f, 25.0f);
        Vector3 randomScale = new Vector3(randomRange, randomRange, randomRange);
        asteroidRb.transform.localScale = randomScale;
        asteroidRb.mass = randomRange;
    }
    
}
