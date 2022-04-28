using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoSpawner : MonoBehaviour
{
    private const int WIDTH = 5, LENGTH = 8;

    public GameObject[] smallCrate;
    public GameObject[] longCrate;
    public GameObject[] largeCrate;

    public int numOfSmall, numOfLong, numOfLarge;

    void Start()
    {

    }

    public void SpawnCargo(int amountSmall, int amountLong, int amountLarge)
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(WIDTH, 3.0f, LENGTH));
    }
}
