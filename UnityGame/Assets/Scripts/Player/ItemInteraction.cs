using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] string targetTag = "Item";
    [SerializeField] float distance = 2.0f;

    public void DetectItem()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, distance);
        
        foreach (var collision in collisions)
        {
            if (collision.CompareTag(targetTag))
            {
                PopUpManager.Instance.Show(AlarmType.OBTAIN);                
                
                return;
            }
        }

        PopUpManager.Instance.Hide(AlarmType.OBTAIN);
    }
}