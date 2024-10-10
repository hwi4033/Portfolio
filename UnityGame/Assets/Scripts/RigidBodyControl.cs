using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class RigidBodyControl : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float runSpeed = 8.0f;
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;
    Animations animations;
    Rigidbody rigidBody;

    private int jumpCount = 0;
    private float h, v;

    public float WalkSpeed
    {
        get { return  walkSpeed; }
        set { walkSpeed = value; }
    }

    private void Awake()
    {
        animations = GetComponent<Animations>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.forward * v + transform.right * h;

        // Vector3 dir = new Vector3(h, 0, v).normalized;

        if (animations.ArrowControl == true)
        {
            Run(dir);
            Move(dir);
            Jump();
        }
    }

    void Move(Vector3 dir)
    {
        if (!(h == 0 && v == 0))
        {
            if (transform.GetComponent<RayCast>().IsWall() != true)
            {
                rigidBody.MovePosition(transform.position + dir * walkSpeed * Time.deltaTime);
                // transform.position += dir * walkSpeed * Time.deltaTime;                
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    void Run(Vector3 dir)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!(h == 0 && v == 0))
            {
                if (transform.GetComponent<RayCast>().IsWall() != true)
                {
                    rigidBody.MovePosition(transform.position + dir * runSpeed * Time.deltaTime);
                    // transform.position += dir * runSpeed * Time.deltaTime;
                }

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
            }
        }     
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount == 0)
        {
            jumpCount++;

            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        jumpCount--;
    }
}