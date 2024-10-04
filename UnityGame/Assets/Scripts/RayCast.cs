using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] float rayDistance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsWall()
    {
        RaycastHit raycastHit;

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, rayDistance))
        {
            return true;
        }
        else return false;
    }
}