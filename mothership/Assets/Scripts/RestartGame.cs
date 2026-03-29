using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (gameManager.gameOverCheck)
            
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                RestartScene();
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
