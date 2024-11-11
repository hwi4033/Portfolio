using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 17.5f;

    public float Damage
    {
        get { return damage; }
    }
}