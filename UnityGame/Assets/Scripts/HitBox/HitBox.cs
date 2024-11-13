using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(HitBoxDetection))]
[RequireComponent(typeof(HitBoxMove))]
[RequireComponent(typeof(HitBoxCollision))]

public class HitBox : MonoBehaviour
{
    [SerializeField] HitBoxDetection hitBoxDetection;
    [SerializeField] HitBoxMove hitBoxMove;
    [SerializeField] HitBoxCollision hitBoxCollision;

    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerPosition;
    [SerializeField] bool isDetected = false;

    private void Awake()
    {
        hitBoxDetection = GetComponent<HitBoxDetection>();
        hitBoxMove = GetComponent<HitBoxMove>();
        hitBoxCollision = GetComponent<HitBoxCollision>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        playerPosition = player.transform.position;

        if (hitBoxDetection.Detection(playerPosition))
        {
            isDetected = true;
        }
        else isDetected = false;
    }

    private void FixedUpdate()
    {
        if (isDetected == true)
        {
            hitBoxMove.Move(playerPosition);
        }
    }
}