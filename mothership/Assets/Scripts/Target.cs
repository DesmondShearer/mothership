using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int points = 100;

    void Start()
    { 
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
        
    }
}
