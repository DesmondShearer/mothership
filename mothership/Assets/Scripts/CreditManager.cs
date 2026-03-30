using UnityEngine;
using TMPro;

public class CreditManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float totalCredits = 0;
    
    void Start()
    {
        totalCredits = 0;
    }
    
    void Update()
    {
        
    }
    
    public void UpdateCredits(float creditsToAdd)
    {
        totalCredits += creditsToAdd;
        Debug.Log(totalCredits);
        scoreText.text = "Credits: " + totalCredits;
    }
}
