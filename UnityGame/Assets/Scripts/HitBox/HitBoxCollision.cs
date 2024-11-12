using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCollision : MonoBehaviour
{
    [SerializeField] GameObject weaponPivot;
    [SerializeField] GameObject playerWeapon;
    [SerializeField] CapsuleCollider capsuleCollider;

    [SerializeField] float health = 100.0f;

    void Awake()
    {
        weaponPivot = GameObject.FindWithTag("WeaponPivot");
        playerWeapon = weaponPivot.transform.GetChild(0).gameObject;
        capsuleCollider = playerWeapon.GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Weapon"))
        {
            Debug.Log(collision.gameObject.name);

            health -= playerWeapon.GetComponent<Weapon>().Damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}