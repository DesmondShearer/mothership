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

    //private float score = 0;
    private int health = 50;
    private float fuel = 100;
    
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
            fuel = 100;
            fuelText.text = "Fuel: " + fuel;
            
            health = 50;
            healthText.text = "Health: " + health;
            
            
        }

        if (!playerController.isDocked)
        {
           menu.gameObject.SetActive(false);
           titleText.gameObject.SetActive(false);
           instructionsText.gameObject.SetActive(false);
           
           fuel -= Time.deltaTime;
           fuelText.text = "Fuel: " + fuel;
           Debug.Log(fuel);
        }

        
        // refactor this. !!
        if (health == 0) 
        {
            gameOverCheck = true;
            gameOver.gameObject.SetActive(true);
            gameOverReasonText.text = "You took too much damage!";
            gameOverText.gameObject.SetActive(true);
            gameOverReasonText.gameObject.SetActive(true);
            gameOverScoreText.text = "You earned " + creditManager.totalCredits + " Credits!";
            gameOverScoreText.gameObject.SetActive(true);
            
            
            if (!alreadyPlayed)
            {
                dieAudio.Play();
                alreadyPlayed = true;
            }
            Debug.Log("Game Over");
        }
        
        if (fuel <= 0)
        {
            gameOverCheck = true;
            gameOver.gameObject.SetActive(true);
            gameOverReasonText.text = "The fuel tank is empty!";
            gameOverText.gameObject.SetActive(true);
            gameOverReasonText.gameObject.SetActive(true);
            gameOverScoreText.text = "You earned " + creditManager.totalCredits + " Credits!";
            gameOverScoreText.gameObject.SetActive(true);
            if (!alreadyPlayed)
            {
                dieAudio.Play();
                alreadyPlayed = true;
            }
            Debug.Log("Game Over");
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
        health -= damageToTake;
        Debug.Log(health);
        healthText.text = "Health: " + health;
    }
}
