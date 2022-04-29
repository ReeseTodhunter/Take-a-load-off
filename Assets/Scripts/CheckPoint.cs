using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameManager gameManager;
    public CargoSpawner cargoSpawner;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cab")
        {
            cargoSpawner.SpawnCargo(gameManager.startingCargoAmount + 1);
            gameManager.startingCargoAmount += 1;
        }
        else if (other.gameObject.name == "Enemy")
        {
            gameManager.gameState = GameState.GameOver;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
