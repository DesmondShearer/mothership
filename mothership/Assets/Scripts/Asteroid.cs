using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Asteroid : MonoBehaviour
{
    private Rigidbody rB;

    public float minScale = 10f;
    public float maxScale = 25f;
    public float minInitialForce = 50f;
    public float maxInitialForce = 80f;
    public float minInitialTorque = 50f;
    public float maxInitialTorque = 80f;
    
    private void Awake()
    {
        float randomScale = Random.Range(minScale, maxScale);
        float randomForce = Random.Range(minInitialForce, maxInitialForce);
        float randomTorque = Random.Range(minInitialTorque, maxInitialTorque);
        
        rB = GetComponent<Rigidbody>();
        
        transform.localScale = Vector3.one * randomScale;
        rB.mass = randomScale;
        
        rB.useGravity = false;
        rB.AddForce(Vector3.forward * randomForce);
        rB.AddTorque(Vector3.forward * randomTorque);
        
    }
}
