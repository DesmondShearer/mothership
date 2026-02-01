using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    Rigidbody asteroidRb;
    
    public float speed = 0.1f;
   
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.rotation = Quaternion.identity;
        asteroidRb.transform.rotation = Random.rotation;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
