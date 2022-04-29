using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public TileSpawner tileSpawner;
    public GameObject truck;
    public GameObject[] tiles;
    public GameObject[] crates;

    public GameState gameState;
    public float cargoWeight;
    public int numOfCargo;
    public int score;
    public int highScore;

    void Awake()
    {
        if (GM == null) //If there is no Game manager create one and make it persistent over all scenes
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)    //If there is already another Game manager destroy this object to avoid collision
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameState = GameState.MainMenu;
        cargoWeight = 0.0f;
        numOfCargo = 0;
        score = 0;
        highScore = 0;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SinglePlayer");
        gameState = GameState.Playing;
        SetupGame();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void SetupGame()
    {
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}