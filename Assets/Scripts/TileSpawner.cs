using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameManager gameManager;

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
        if (other.gameObject.name == "Truck")
        {
            if (!hasSpawnedTile && gameManager.tiles != null)
            {
                SpawnTile(new Vector3(this.transform.position.x, 0.0f, this.transform.position.z + spawnOffset), gameManager.tiles[Random.Range(0, gameManager.tiles.Length - 1)]); //Spawns a new Tile from the tile list and positions it ahead
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        killTimerStarted = true;
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
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
