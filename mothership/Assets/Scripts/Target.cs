using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int points = 100;

    //private GameManager gameManager;

    void Start()
    { 
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //gameManager.UpdateScore(points);
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
