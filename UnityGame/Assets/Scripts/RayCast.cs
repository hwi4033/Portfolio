using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsWall();
    }

    void IsWall()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 2.0f, transform.forward, 0.2f))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
        }
    }
}
