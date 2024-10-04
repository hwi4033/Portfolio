using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animations))]

public class RigidBodyControl : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float runSpeed = 8.0f;
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;
    Animations animations;
    Rigidbody rigidBody;
    // private bool isGround = false;
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
        // CheckGround();
    }

    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        // rigidBody.velocity = Vector3.zero;
        // rigidBody.angularVelocity = Vector3.zero;

        if (animations.ArrowControl == true)
        {
            Run(dir);
            Move(dir);
            Jump();
        }                  
    }

    void Move(Vector3 dir)
    {
        // h = Input.GetAxisRaw("Horizontal");
        // v = Input.GetAxisRaw("Vertical");
        // 
        // Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            if (transform.GetComponent<RayCast>().IsWall() != true)
            {
                transform.position += dir * walkSpeed * Time.deltaTime;                
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    void Run(Vector3 dir)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // h = Input.GetAxisRaw("Horizontal");
            // v = Input.GetAxisRaw("Vertical");
            // 
            // Vector3 dir = new Vector3(h, 0, v);

            if (!(h == 0 && v == 0))
            {
                if (transform.GetComponent<RayCast>().IsWall() != true)
                {
                    transform.position += dir * runSpeed * Time.deltaTime;
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

    // private void CheckGround()
    // {
    //     RaycastHit hit;
    // 
    //     if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.01f))
    //     {
    //         if (hit.transform.CompareTag("Ground"))
    //         {
    //             isGround = true;
    // 
    //             return;
    //         }
    //     }
    // 
    //     isGround = false;
    // }
}