using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Animator animator;
    GameObject grabbedObj;
    public Rigidbody rb;
    public int isLeftorRight;
    bool toGrab = false;
    public bool alreadyGrabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetBool("isLeftHandUp", true);
            if (!alreadyGrabbing)
            {
                toGrab = true;
                //alreadyGrabbing = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isRightHandUp", true);
            if (!alreadyGrabbing)
            {
                toGrab = true;
                //alreadyGrabbing = true;
            }
        }
        



        if (Input.GetKeyUp(KeyCode.J))
        {
            if (alreadyGrabbing)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint>());
            }
            animator.SetBool("isLeftHandUp", false);
            toGrab = false;
            
            

        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (alreadyGrabbing)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint>());
            }
            animator.SetBool("isRightHandUp", false);
            toGrab = false;
        }



        if(grabbedObj != null && toGrab == false && alreadyGrabbing == false)
        {
            Destroy(grabbedObj.GetComponent<FixedJoint>());
        }

        grabbedObj = null;
        Debug.Log(grabbedObj);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>() as Cargo != null)
        {
            grabbedObj = other.gameObject;
            Debug.Log("Obj Detected");
            if (toGrab && !alreadyGrabbing)
            {
                FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
                fj.connectedBody = rb;
                fj.breakForce = 9001;
                alreadyGrabbing = true;
                toGrab = false;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        grabbedObj = null;
        alreadyGrabbing = false;
        Destroy(other.GetComponent<FixedJoint>());
        Destroy(grabbedObj.GetComponent<FixedJoint>());

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Cargo>() as Cargo != null)
        {
            Destroy(other.GetComponent<FixedJoint>());

        }
    }
}

