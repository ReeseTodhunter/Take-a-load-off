using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private const float BASE_SPEED = 100.0f;
    private const float LOWEST_SPEED = 50.0f;

    public CargoDetector cargoDetector;
    
    private GameObject tile;
    private float speedModifier;

    void Start()
    {
        tile = this.gameObject;
    }

    void FixedUpdate()
    {
        if (cargoDetector != null)
        {
            MoveTile(cargoDetector.totalCargoWeight);
        }
    }

    public void MoveTile(float cargoWeight)
    {
        float moveSpeed;
        if (BASE_SPEED - cargoWeight < LOWEST_SPEED)
        {
            moveSpeed = LOWEST_SPEED * Time.deltaTime;
        }
        else
        {
            moveSpeed = (BASE_SPEED - cargoWeight) * Time.deltaTime;
        }
        tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z - moveSpeed);
    }
}