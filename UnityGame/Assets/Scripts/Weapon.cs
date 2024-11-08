using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animations animations;

    private void Awake()
    {
        animations = GetComponent<Animations>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}