using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float strafespeed;
    public float jumpForce;

    public Rigidbody Pelvis;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        Pelvis = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Pelvis.AddForce(Pelvis.transform.forward * speed);
        }


        if(Input.GetAxis("Jump")>0)
        {
            if (isGrounded)
            {
                Pelvis.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
