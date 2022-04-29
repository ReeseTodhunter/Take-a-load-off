using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoDetector : MonoBehaviour
{
    public GameManager gameManager;

    public float totalCargoWeight; //Stores the weight of all cargo on the truck
    int numOfCargo; //Stores number of boxes in the truck

    //void Awake()
    //{
    //    gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    //}

    void Start()
    {
        totalCargoWeight = 0.0f;
        numOfCargo = 0;
    }

    void Update()
    {
        gameManager.numOfCargo = numOfCargo;
        gameManager.cargoWeight = totalCargoWeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>() as Cargo != null)
        {
            other.GetComponent<Cargo>().inTruck = true;
            totalCargoWeight = totalCargoWeight + other.GetComponent<Cargo>().weight;
            numOfCargo++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Cargo>() as Cargo != null)
        {
            other.GetComponent<Cargo>().inTruck = false;
            totalCargoWeight = totalCargoWeight - other.GetComponent<Cargo>().weight;
            numOfCargo--;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}