using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private int JumpTimer = 120;
    public float speed = 200;
    public float strafespeed = 150;
    public float jumpForce = 6000;

    public Rigidbody Pelvis;
    public bool isGrounded;

    public float turnSmoothTime = 2f;
    float turnSmoothVelocity;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("AnimationModel").GetComponent(typeof(Animator)) as Animator;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Pelvis.AddForce(Pelvis.transform.forward * speed);

            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }


        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded && JumpTimer > 30)
            {
                Pelvis.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
                JumpTimer = 0;
            }
        }
        if (isGrounded && JumpTimer <= 30)
        {
            JumpTimer += 1;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            animator.SetBool("isSpin", true);
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            animator.SetBool("isSpin", false);
        }
    }
        
}
