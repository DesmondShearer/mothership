using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public TargetType targetType;

    void Start()
    { 
        health = targetType.maxHealth;
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
