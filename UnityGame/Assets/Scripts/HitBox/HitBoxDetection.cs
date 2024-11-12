using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBoxDetection : MonoBehaviour
{
    [SerializeField] float distance = 8.0f;

    public bool Detection(Vector3 player)
    {
        if (Vector3.Distance(transform.position, player) <= distance)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
}