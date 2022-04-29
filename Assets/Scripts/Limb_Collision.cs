using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb_Collision : MonoBehaviour
{
    public Player_Controller playerController;

    private void Start()
    {
        //playerController = GameObject.FindObjectOfType<Player_Controller>().GetComponent<Player_Controller>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isGrounded = true;
    }
}
