using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Transform weaponPivot;
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] GameObject rightWeapon;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();

        rightWeapon = weaponPivot.GetChild(0).gameObject;
        capsuleCollider = rightWeapon.GetComponent<CapsuleCollider>();

        capsuleCollider.enabled = false;
    }

    public void AttackStart()
    {
        Debug.Log("Start");
        capsuleCollider.enabled = true;
    }

    public void AttackEnd()
    {
        Debug.Log("End");
        capsuleCollider.enabled = false;
    }
}