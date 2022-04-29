using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameManager gameManager;

    private const float BASE_SPEED = 120.0f;
    private const float LOWEST_SPEED = 50.0f;
    
    private GameObject tile;
    private float speedModifier;

    void Start()
    {
        tile = this.gameObject;
    }

    void FixedUpdate()
    {
        if (gameManager != null)
        {
            MoveTile(gameManager.cargoWeight);
        }
    }

    public void MoveTile(float cargoWeight)
    {
        float moveSpeed;
        if (BASE_SPEED - cargoWeight < LOWEST_SPEED)
        {
            moveSpeed = LOWEST_SPEED * Time.deltaTime;
            gameManager.playerSpeed = LOWEST_SPEED;
        }
        else
        {
            moveSpeed = (BASE_SPEED - cargoWeight) * Time.deltaTime;
            gameManager.playerSpeed = BASE_SPEED - cargoWeight;
        }
        tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z - moveSpeed);
    }
}