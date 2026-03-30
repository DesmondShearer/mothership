using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private int initialPlayerHealth = 50;
    private int currentPlayerHealth;
    private float initialPlayerFuel = 100;
    private float currentPlayerFuel;
    
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

    public Image upgradesMenu;
    
    public bool gameOverCheck;
    
    public AudioSource dieAudio;
    public bool alreadyPlayed = false;
    
    void Start()
    {
        gameOverCheck = false;
        gameOver.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverReasonText.gameObject.SetActive(false);
        gameOverScoreText.gameObject.SetActive(false);
        
    }
    
    void Update()
    {
        if (playerController.isDocked)
        {
            menu.gameObject.SetActive(true);
            titleText.gameObject.SetActive(true);
            instructionsText.gameObject.SetActive(true);
            upgradesMenu.gameObject.SetActive(true);
            Cursor.visible = true;
            
            
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
           upgradesMenu.gameObject.SetActive(false);
           Cursor.visible = false;
           
           currentPlayerFuel -= Time.deltaTime;
           fuelText.text = "Fuel: " + currentPlayerFuel;
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
    
    public void RemoveHealth(int damageToTake)
    {
        currentPlayerHealth -= damageToTake;
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
