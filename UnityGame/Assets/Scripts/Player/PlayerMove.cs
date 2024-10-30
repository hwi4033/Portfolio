using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    [SerializeField] float walkSpeed = 5.0f;
    [SerializeField] float runSpeed = 10.0f;
    [SerializeField] float rotateSpeed = 5.0f;

    public void Movement(Rigidbody rigidBody)
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction = transform.forward * direction.z + transform.right * direction.x;

        if (!(direction.x == 0 && direction.z == 0))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rigidBody.MovePosition(transform.position + direction * runSpeed * Time.deltaTime);
            }
            else
            {
                rigidBody.MovePosition(transform.position + direction * walkSpeed * Time.deltaTime);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotateSpeed);
        }
    }
}