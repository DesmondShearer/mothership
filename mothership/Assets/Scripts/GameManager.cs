using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int asteroidCount = 30;

    private int score;
    private int health;
    private float fuel;
    private int initialHealth = 50;
    private float initialFuel = 100;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI fuelText;
    
    public PlayerController playerController;
    
    public Image menu;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI instructionsText;

    public Image gameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverReasonText;
    public TextMeshProUGUI gameOverScoreText;

    public bool gameOverCheck;
    
    public AudioSource dieAudio;
    public bool alreadyPlayed = false;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverCheck = false;
        int index = Random.Range(0, targets.Count);
        for (int i = 1; i <= asteroidCount; i++)
        {
            Instantiate(targets[index]);
        }
        gameOver.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverReasonText.gameObject.SetActive(false);
        gameOverScoreText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.isDocked)                          // if player is docked, menu/title text/instructions appear
        {                                                       //fuel & health is set to initial 
            menu.gameObject.SetActive(true);                                      
            titleText.gameObject.SetActive(true);
            instructionsText.gameObject.SetActive(true);
            fuel = initialFuel;
            fuelText.text = "Fuel: " + fuel;
            
            health = initialHealth;
            healthText.text = "Health: " + health;
            
            
        }

        if (!playerController.isDocked)                         // if player is not docked, menu/title/instruction do not appear, fuel reduces with time
        {
           menu.gameObject.SetActive(false);
           titleText.gameObject.SetActive(false);
           instructionsText.gameObject.SetActive(false);
           
           fuel -= Time.deltaTime;
           fuelText.text = "Fuel: " + fuel;
           Debug.Log(fuel);
        }

        
        
        if (health == 0)                                         // if player health is 0, game is over, game over due to damage text displays,
                                                                 // final score displays
        {
            GameOver();          
            gameOverReasonText.text = "You took too much damage!";
           
        }
        
        if (fuel <= 0)                                           // if fuel is 0, game is over, game over due to empty tank displays,
                                                                 // final score displays
        {
            GameOver();        
            gameOverReasonText.text = "The fuel tank is empty!";
            
        }
        
    }
    public void UpdateScore(int scoreToAdd)                     // score display updates with points gained
    {
        score += scoreToAdd;
        Debug.Log(score);
        scoreText.text = "Credits: " + score;
        
    }
    
    public void RemoveHealth(int damageToTake)                  // health display updates with damage taken
    {
        health -= damageToTake;
        Debug.Log(health);
        healthText.text = "Health: " + health;
    }

    void GameOver()
    {
        gameOverCheck = true;
        gameOver.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOverReasonText.gameObject.SetActive(true);
        gameOverScoreText.text = "You earned " + score + " Credits!";
        gameOverScoreText.gameObject.SetActive(true);


        if (!alreadyPlayed)                                  // if not already played, audio plays
        {
            dieAudio.Play();
            alreadyPlayed = true;
        }
        Debug.Log("Game Over");

    }

 
}
