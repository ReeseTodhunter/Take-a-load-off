using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public bool inTruck = false;
    private float timer;
    public float destroyTime = 3.0f;
    public float weight = 1.0f;

    void Start()
    {
        timer = destroyTime;
    }

    void FixedUpdate()
    {
        if (!inTruck)
        {
            if (timer < 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                timer = timer - Time.deltaTime;
            }
        }
        else
        {
            timer = destroyTime;
        }
    }
}