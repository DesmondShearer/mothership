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
    
    public void UpdateCredits(float creditsToAdd)
    {
        totalCredits += creditsToAdd;
        scoreText.text = "Credits: " + totalCredits;
    }
}
