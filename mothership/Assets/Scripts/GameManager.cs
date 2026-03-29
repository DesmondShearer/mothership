using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // TO DO
    // create spawn manager
    // remove spawner from gamemanger
    
    // spawn manager
    // containers random size/ scale /position instead of seperate scripts.
    
    //public List<GameObject> targets;
    //private int asteroidCount = 30;
    //private float spawnRadius = 50;
    
    private int initialPlayerHealth = 50;
    private int currentPlayerHealth;
    private float initialPlayerFuel = 100;
    private float currentPlayerFuel;
    
    //public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI fuelText;
    
    public PlayerController playerController;
    
    public CreditManager creditManager;
    
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
        //stop spawning asteroids here
                
        //int index = Random.Range(0, targets.Count);
        //for (int i = 1; i <= asteroidCount; i++)
        //{
        //    Instantiate(targets[index]);
        //}
                
        gameOverCheck = false;
        gameOver.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverReasonText.gameObject.SetActive(false);
        gameOverScoreText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.isDocked)
        {
            menu.gameObject.SetActive(true);
            titleText.gameObject.SetActive(true);
            instructionsText.gameObject.SetActive(true);
            currentPlayerFuel = initialPlayerFuel;
            fuelText.text = "Fuel: " + currentPlayerFuel;
            
            currentPlayerHealth = initialPlayerHealth;
            healthText.text = "Health: " + currentPlayerHealth;
            
            
        }

        if (!playerController.isDocked)
        {
           menu.gameObject.SetActive(false);
           titleText.gameObject.SetActive(false);
           instructionsText.gameObject.SetActive(false);
           
           currentPlayerFuel -= Time.deltaTime;
           fuelText.text = "Fuel: " + currentPlayerFuel;
           //Debug.Log(fuel);
        }
        
        if (currentPlayerHealth == 0)
        {
            GameOver();
            gameOverReasonText.text = "You took too much damage!";
        }
        
        if (currentPlayerFuel <= 0)
        {
            GameOver();
            gameOverReasonText.text = "The fuel tank is empty!";
        }
        
    }
    
    //score manager
  //  public void UpdateScore(float scoreToAdd)
   // {
   //     score += scoreToAdd;
   //     Debug.Log(score);
   //     scoreText.text = "Credits: " + score;
        
   // }
    //for player health script
    public void RemoveHealth(int damageToTake)
    {
        currentPlayerHealth -= damageToTake;
        //Debug.Log(health);
        healthText.text = "Health: " + currentPlayerHealth;
    }

    public void GameOver()
    {
        gameOverCheck = true;
        gameOver.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOverReasonText.gameObject.SetActive(true);
        gameOverScoreText.text = "You earned " + creditManager.totalCredits + " Credits!";
        gameOverScoreText.gameObject.SetActive(true);
            
            
        if (!alreadyPlayed)
        {
            dieAudio.Play();
            alreadyPlayed = true;
        }
    }
}
