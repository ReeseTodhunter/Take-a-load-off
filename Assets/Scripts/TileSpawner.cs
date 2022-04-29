using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public CargoSpawner cargoSpawner;

    private bool hasSpawnedTile;
    private float spawnOffset;
    private bool killTimerStarted;
    private float killTimer;

    void Start()
    {
        hasSpawnedTile = false;
        spawnOffset = 90.0f;
        killTimerStarted = false;
        killTimer = 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cab")
        {
            if (!hasSpawnedTile && gameManager.tiles[Random.Range(0, gameManager.tiles.Length - 1)] != null && gameManager.tilesBetweenCheckpoints > 0)
            {
                gameManager.tilesBetweenCheckpoints -= 1;
                SpawnTile(new Vector3(this.transform.position.x, 0.0f, this.transform.position.z + spawnOffset), gameManager.tiles[Random.Range(0, gameManager.tiles.Length - 1)]); //Spawns a new Tile from the tile list and positions it ahead
            }
            else if(!hasSpawnedTile && gameManager.checkpoint != null && gameManager.tilesBetweenCheckpoints <= 0)
            {
                gameManager.tilesBetweenCheckpoints = 60;
                cargoSpawner = other.gameObject.transform.parent.gameObject.transform.Find("CargoSpawner").gameObject.GetComponent<CargoSpawner>();
                SpawnTile(new Vector3(this.transform.position.x, 0.0f, this.transform.position.z + spawnOffset), gameManager.checkpoint);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cab")
        {
            killTimerStarted = true;
        }
    }

    void Update()
    {
        if (killTimerStarted)
        {
            killTimer -= Time.deltaTime;
            if (killTimer < 0)
            {
                Destroy(this.gameObject.transform.parent.gameObject);
            }
        }
    }

    public void SpawnTile(Vector3 location, GameObject tile)
    {
        GameObject newTile = Instantiate(tile, location, Quaternion.identity);
        newTile.AddComponent<TileController>();
        newTile.GetComponent<TileController>().gameManager = gameManager;
        newTile.transform.Find("SpawnTrigger").gameObject.GetComponent<TileSpawner>().gameManager = gameManager;
        if (tile == gameManager.checkpoint)
        {
            newTile.transform.Find("CheckPoint").gameObject.GetComponent<CheckPoint>().gameManager = gameManager;
            newTile.transform.Find("CheckPoint").gameObject.GetComponent<CheckPoint>().cargoSpawner = cargoSpawner;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
