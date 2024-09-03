using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RigidBodyControl : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float runSpeed = 8.0f;
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] float jumpForce = 5.0f;
    Rigidbody rigidBody;
    private bool isGround = false;
    private float h, v;

    public float Speed
    {
        get { return walkSpeed; }
        set { walkSpeed = value; }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckGround();
    }

    void FixedUpdate()
    {
        Run();
        Move();     
        Jump();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * walkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(h, 0, v);

            if (!(h == 0 && v == 0))
            {
                transform.position += dir * runSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
            }
        }     
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                isGround = true;

                return;
            }
        }

        isGround = false;
    }
}