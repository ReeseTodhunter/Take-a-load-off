using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    private const float WIDTH = 5.0f, LENGTH = 7.5f, HEIGHT = 7.0f;
    private const float GAP_BETWEEN_CARGO = 1.25f;

    public GameManager gameManager;
    [Space]
    [Range(5, 200)]
    public int numToSpawn;
    [Range(0.5f, 1.0f)]
    public float weightToSpawn = 0.5f;

    //void Awake()
    //{
    //    gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    //}

    void Start()
    {
        SpawnCargo(numToSpawn);
    }

    public void SpawnCargo(int numToSpawn = 40)
    {
        int numOfLayers;
        if (numToSpawn > 0)
        {
            numOfLayers = 1 + (int)(numToSpawn / (WIDTH * LENGTH));
        }
        else
        {
            numOfLayers = 0;
        }

        for (int h = 0; h < numOfLayers; h++)
        {
            for (float i = 0; i < LENGTH; i++)
            {
                for (float j = 0; j < WIDTH; j++)
                {
                    if (numToSpawn < 1)
                    {
                        return;
                    }

                    GameObject cargo = Instantiate(gameManager.crates[0], new Vector3(this.transform.position.x + (j * GAP_BETWEEN_CARGO), this.transform.position.y + (h * GAP_BETWEEN_CARGO), this.transform.position.z + (i * GAP_BETWEEN_CARGO)), Quaternion.identity);
                    cargo.AddComponent<Cargo>();
                    cargo.GetComponent<Cargo>().weight = weightToSpawn;
                    numToSpawn--;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(this.transform.position.x + (WIDTH / 2), this.transform.position.y, this.transform.position.z + (LENGTH / 2)), new Vector3(WIDTH, 1.0f, LENGTH));
    }
}
