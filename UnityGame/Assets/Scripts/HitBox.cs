using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] Transform weaponPivot;
    [SerializeField] GameObject playerWeapon;
    [SerializeField] CapsuleCollider capsuleCollider;

    [SerializeField] float health = 100.0f;

    void Awake()
    {
        playerWeapon = weaponPivot.GetChild(0).gameObject;
        capsuleCollider = playerWeapon.GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.collider.CompareTag("Weapon"))
        // {
        //     Debug.Log(collision.gameObject.name);
        // 
        //     health -= playerWeapon.GetComponent<Weapon>().Damage;
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Debug.Log(other.gameObject.name);

            health -= playerWeapon.GetComponent<Weapon>().Damage;
        }
    }
}