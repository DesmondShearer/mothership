using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;  // target health
    public int points = 100;    // points target is worth



    public void TakeDamage(float amount)
    {
        health -= amount;           // reduce target health by amount of damage caused by laser
        if (health <= 0)
        {           
            Die();                  // if health reaches 0, run Die method
        }
    }

    void Die()
    {        
        Destroy(gameObject);        // target is destroyed
    }
}
