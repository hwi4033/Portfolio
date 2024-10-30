using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator animator;
    private RigidBodyControl rb;
    private float hAxis;
    private float vAxis;
    private bool arrowControl = true;

    public bool ArrowControl
    {
        get { return arrowControl; }
    }

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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
            {
                OnAttack();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && arrowControl)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
            {
                OnJump();
            }           
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
        animator.SetTrigger("Jump");
    }

    public void OnAttack()
    {
        animator.SetTrigger("Attack01");
    }

    public void ArrowTrue()
    {
        arrowControl = true;
    }

    public void ArrowFalse()
    {
        arrowControl = false;
    }
}
