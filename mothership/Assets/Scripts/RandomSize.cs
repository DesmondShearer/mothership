using UnityEngine;

public class RandomSize : MonoBehaviour
{
    private Rigidbody asteroidRb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();

        float randomRange = Random.Range(10.0f, 25.0f); // asks for a float in the range of 10 - 25
        Vector3 randomScale = new Vector3(randomRange, randomRange, randomRange); //scale in x,y,z is the aforementioned random number
        asteroidRb.transform.localScale = randomScale; //asteroid is transformed to previously calculated random scale
        asteroidRb.mass = randomRange; // mass of asteroid is set to previously calcuated random range
    }

}
