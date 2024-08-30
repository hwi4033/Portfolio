using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RigidBodyControl : MonoBehaviour
{
    bool isGrounded;
    Rigidbody rigidbody;
    Vector3 direction = Vector3.zero;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] LayerMask ground;
    [SerializeField] float groundDistance = 0.2f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
    }

    public void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * -Physics.gravity.y);
            rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
        }
    }

    public void GroundCheck()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, Vector3.down, out raycastHit, groundDistance, ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}