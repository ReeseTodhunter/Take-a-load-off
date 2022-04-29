using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    public void Retry()
    {
        if (gameManager != null)
        {
            gameManager.LoadGame();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameManager.gameState = GameState.MainMenu;
    }
}