using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;

    private float enemySpeed;
    private float playerSpeed;
    private float currentSpeed;

    void Start()
    {
        enemySpeed = 80.0f;
    }

    void Update()
    {
        playerSpeed = gameManager.playerSpeed;

        if ((enemySpeed >= playerSpeed && this.transform.position.z < gameManager.playerPos.z + 150.0f) || (enemySpeed <= playerSpeed && this.transform.position.z > gameManager.playerPos.z - 150.0f))
        {
            currentSpeed = (enemySpeed - playerSpeed) * Time.deltaTime;
        }
        else
        {
            currentSpeed = 0.0f;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + currentSpeed);
    }
}
