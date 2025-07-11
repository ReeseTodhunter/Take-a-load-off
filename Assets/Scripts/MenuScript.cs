using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    public void Playgame()
    {
        gameManager.LoadGame();
    }

    public void Quit()
    {
        gameManager.Quit();
    }
}
