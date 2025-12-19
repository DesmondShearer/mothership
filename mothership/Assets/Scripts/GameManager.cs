using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int asteroidCount = 50;

    public int score;
    public TextMeshProUGUI scoreText;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        int index = Random.Range(0, targets.Count);
        for (int i = 1; i <= asteroidCount; i++)
        {
            Instantiate(targets[index]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log(score);
        scoreText.text = "Score: " + score;
        
    }
}
