using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMove : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    public void Move(Rigidbody rigidBody, Vector3 player)
    {
        rigidBody.MovePosition(rigidBody.position + player * speed * Time.deltaTime);
        // transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
    }
}