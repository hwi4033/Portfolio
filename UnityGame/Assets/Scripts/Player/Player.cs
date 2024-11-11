using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animations))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(ItemInteraction))]

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] Animations animations;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerJump playerJump;
    [SerializeField] ItemInteraction itemInteraction;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        animations = GetComponent<Animations>();
        playerAttack = GetComponent<PlayerAttack>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        itemInteraction = GetComponent<ItemInteraction>();
    }

    private void Update()
    {
        itemInteraction.DetectItem();
    }

    private void FixedUpdate()
    {
        if (animations.ArrowControl == true)
        {
            playerMove.Movement(rigidBody);
            playerJump.Jump(rigidBody);
        }
    }
}