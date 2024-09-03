using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(RigidBodyControl))]

public class Animations : MonoBehaviour
{
    [SerializeField] Animator animator;
    private RigidBodyControl rb;
    private float hAxis;
    private float vAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        if (hAxis == 0 && vAxis == 0)
        {
            OnIdle();
        }
        else if (hAxis != 0 || vAxis != 0)
        {
            OnWalk();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                OnRun();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnAttack();
        }
    }

    public void OnIdle()
    {
        animator.SetBool("Walk", false);
    }

    public void OnWalk()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
    }

    public void OnRun()
    {
        animator.SetBool("Run", true);
    }

    public void OnJump()
    {

    }

    public void OnAttack()
    {
        animator.SetTrigger("Attack01");
    }
}
