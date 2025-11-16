using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    Rigidbody asteroidRb;
    
    public float speed = 0.05f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        asteroidRb.AddForce(transform.forward * speed *  Time.deltaTime, ForceMode.VelocityChange);
        asteroidRb.AddTorque(transform.up * speed*  Time.deltaTime, ForceMode.VelocityChange);
    }
}
