using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    Rigidbody asteroidRb;
    
    public float speed = 0.1f;
    //private float maxTorque = 0.5f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        asteroidRb.rotation = Quaternion.identity;
        asteroidRb.transform.rotation = Random.rotation;
        //asteroidRb.AddForce(transform.forward * Random.Range(0,speed), ForceMode.VelocityChange);
        //float randomTorque = Random.Range(-maxTorque, maxTorque);
        //asteroidRb.AddTorque(randomTorque,randomTorque,randomTorque, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
