using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public TargetType configuration;

    void Start()
    { 
        health = configuration.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
