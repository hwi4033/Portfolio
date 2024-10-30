using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MainCameraCenter : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    
    [SerializeField] Vector3 offset;

    void Start()
    {
        target = GameObject.Find("Player");

        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        transform.position = target.transform.position + offset;

        // transform.rotation = target.transform.rotation;
    }
}