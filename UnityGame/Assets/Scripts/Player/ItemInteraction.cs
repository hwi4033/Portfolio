using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Items item;

    [SerializeField] string targetTag = "Item";
    [SerializeField] float distance = 2.0f;

    public void DetectItem()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, distance);
        
        foreach (var collision in collisions)
        {
            if (collision.CompareTag(targetTag))
            {
                item = collision.gameObject.GetComponent<Items>();

                PopUpManager.Instance.Show(AlarmType.OBTAIN);

                ObtainItem(collision.gameObject);

                return;
            }
        }

        PopUpManager.Instance.Hide(AlarmType.OBTAIN);
    }

    public void ObtainItem(GameObject collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.GetComponent<Inventory>().AddItem(item);

            // Destroy(collision);
        }
    }
}