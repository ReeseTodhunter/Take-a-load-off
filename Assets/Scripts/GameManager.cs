using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public TileSpawner tileSpawner;
    public GameObject truck;
    public GameObject enemy;
    public GameObject checkpoint;
    public GameObject[] tiles;
    public GameObject[] crates;

    public GameState gameState;
    public Vector3 playerPos;
    public float cargoWeight;
    public float playerSpeed;
    public float enemySpeed;
    public int numOfCargo;
    public int startingCargoAmount;
    public int tilesBetweenCheckpoints;
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
        playerPos = new Vector3(-6.5f, 3.0f, 0.0f);
        startingCargoAmount = 40;
        tilesBetweenCheckpoints = 30;
        cargoWeight = 0.0f;
        numOfCargo = 0;
        score = 0;
        highScore = 0;
    }

    void Update()
    {
        if (gameState == GameState.GameOver)
        {
            GameOver();
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SinglePlayer");
        gameState = GameState.Playing;
        if (SceneManager.GetActiveScene().name != "SinglePlayer")
        {
            StartCoroutine("waitForSceneLoad", "SinglePlayer");
        }
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
        float setupOffset = -30.0f;

        for (int i = 0; i < 5; i++)
        {
            GameObject tile = Instantiate(tiles[0], new Vector3(0.0f, 0.0f, setupOffset), Quaternion.identity);
            tile.GetComponent<TileController>().gameManager = GM;
            tile.transform.Find("SpawnTrigger").gameObject.GetComponent<TileSpawner>().gameManager = GM;
            setupOffset += 30.0f;
        }

        GameObject newTruck = Instantiate(truck, playerPos, Quaternion.Euler(0.0f, 90.0f, 0.0f));
        newTruck.transform.Find("CargoSpawner").gameObject.GetComponent<CargoSpawner>().gameManager = GM;
        newTruck.transform.Find("CargoDetector").gameObject.GetComponent<CargoDetector>().gameManager = GM;
        GameObject newEnemy = Instantiate(enemy, new Vector3(-playerPos.x, playerPos.y, playerPos.z - 150.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
        newEnemy.GetComponent<Enemy>().gameManager = GM;
    }

    private void GameOver()
    {

    }

    IEnumerator waitForSceneLoad(string sceneName)
    {
        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return null;
        }
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            SetupGame();
        }
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}