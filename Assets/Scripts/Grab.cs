using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Animator animator;
    GameObject grabbedObj;
    public Rigidbody rb;
    public int isLeftorRight;
    public bool alreadyGrabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(isLeftorRight))
        {
            if(isLeftorRight == 0)
            {
                animator.SetBool("isLeftHandUp", true);
            }
            else if (isLeftorRight == 1)
            {
                animator.SetBool("isRightHandUp", true);
            }

            FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 9001;
        }
        else if(Input.GetMouseButtonUp(isLeftorRight))
        {
            if(isLeftorRight == 0)
            {
                animator.SetBool("isLeftHandUp", false);
            }
            else if (isLeftorRight == 1)
            {
                animator.SetBool("isRightHandUp", false);
            }

            if(grabbedObj != null)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint>());
            }

            grabbedObj = null;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>() as Cargo != null)
        {
            grabbedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        grabbedObj = null;

    }
}
