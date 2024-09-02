using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    IDLE,
    WALK
}

public class Animations : MonoBehaviour
{
    [SerializeField] Animator animator;
    private State state;
    private float hAxis;
    private float vAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        if (hAxis == 0 && vAxis == 0)
        {
            OnIdle();
        }
        else if (hAxis != 0 || vAxis != 0)
        {
            OnWalk();
        }
    }

    public void OnIdle()
    {
        animator.SetBool("Walking", false);
    }

    public void OnWalk()
    {
        animator.SetBool("Walking", true);
    }

    public void OnRun()
    {

    }

    public void OnJump()
    {

    }
}
