using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOverCheck)                  // if game is over and escape is pressed, scene is restarted
            
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                RestartScene();
            }
        }
    }

    public void RestartScene()                          // reloads scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
