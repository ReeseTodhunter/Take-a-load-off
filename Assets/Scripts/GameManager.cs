using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float destructionDelay = 2.0f;
    public TileSpawner tileSpawner;
    public CargoSpawner cargoSpawner;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        float tileOffset = -30.0f;
        for (int i = 0; i < 5; i++)
        {
            tileSpawner.SpawnTile(new Vector3(0.0f, 0.0f, tileOffset), tileSpawner.tile[0]);
            tileOffset += 30.0f;
        }
    }
}