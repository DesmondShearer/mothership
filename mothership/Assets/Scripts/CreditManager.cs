using UnityEngine;
using TMPro;

public class CreditManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float totalCredits = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalCredits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //score manager
    public void UpdateCredits(float creditsToAdd)
    {
        totalCredits += creditsToAdd;
        Debug.Log(totalCredits);
        scoreText.text = "Credits: " + totalCredits;
        
    }
}
