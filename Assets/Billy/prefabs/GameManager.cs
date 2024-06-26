using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public int playerCredits;
    public int playerDeaths;
    public bool isGameOver = false;
    [SerializeField]
    public UnityEngine.SceneManagement.Scene scene; 
    bool isMainMenu = false;
    public Canvas mainMenu;
    

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize or set up initial game state here
        if (true)
        {
            LoadLevel("Assets/Billy/scenes/MainMenu.unity");
            scene = SceneManager.GetSceneByPath("Assets/Billy/scenes/MainMenu.unity");
            Debug.Log(scene.name);
            isMainMenu = true;
        }
    }

    private void Update()
    {

        if (isMainMenu && Input.GetKeyDown(KeyCode.Space))
        {
            StartNewGame();
        }

        

    }

    public void StartNewGame()
    {
        // Reset game state for a new playthrough
        playerCredits = 0;
        playerDeaths = 0;
        isGameOver = false;

        // Load the initial game scene
        isMainMenu = false;
        LoadLevel("Assets/Billy/scenes/OpeningScene.unity");
        scene = SceneManager.GetSceneByPath("Assets / Billy / scenes / OpeningScene.unity");


    }

    public void PlayerDied()
    {
        // Handle player death
        playerDeaths++;
    }

    private void RespawnPlayer()
    {
        // Implement player respawn logic here
        // This could involve resetting player position, health, etc.
    }

    public void CollectCoin(int value)
    {
        // Handle collecting coins or other score-awarding items
        playerCredits += value;
    }

    private void GameOver()
    {
        // Handle game over conditions
        isGameOver = true;

        // You might show a game over screen, prompt for restart, etc.
    }



    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        // Restart the game from the beginning
        StartNewGame();
    }
}
