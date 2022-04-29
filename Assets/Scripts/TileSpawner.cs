using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tile;
    public CargoDetector cargoDetector;

    private bool hasSpawned;
    private float spawnDistance;
    private bool killTimerStarted;
    private float killTimer;

    void Start()
    {
        hasSpawned = false;
        spawnDistance = 90.0f;
        killTimerStarted = false;
        killTimer = 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Truck")
        {
            Debug.Log("A Truck!");
            if (!hasSpawned && tile != null)
            {
                SpawnTile(new Vector3(this.transform.position.x, 0.0f, this.transform.position.z + spawnDistance), tile[Random.Range(0, tile.Length - 1)]);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        killTimerStarted = true;
    }

    void FixedUpdate()
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
        if (cargoDetector != null)
        {
            newTile.GetComponent<TileController>().cargoDetector = cargoDetector;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
