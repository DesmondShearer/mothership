using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int asteroidCount = 30;
    private float spawnRadius = 50;

    private int score = 0;
    private int health = 100;
    private float fuel = 100;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI fuelText;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        int index = Random.Range(0, targets.Count);
        for (int i = 1; i <= asteroidCount; i++)
        {
            Instantiate(targets[index]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        fuel -= Time.deltaTime;
        fuelText.text = "Fuel: " + fuel;
        Debug.Log(fuel);
        
        if (health == 0)
        {
            Debug.Log("Game Over");
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log(score);
        scoreText.text = "Credits: " + score;
        
    }
    
    public void RemoveHealth(int damageToTake)
    {
        health -= damageToTake;
        Debug.Log(health);
        healthText.text = "Health: " + health;
    }
}
