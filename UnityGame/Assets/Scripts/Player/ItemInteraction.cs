using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] Slot[] slots;
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
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                {
                    slots[i].Item.GetComponent<Slot>().AddItem(collision.GetComponent<Items>().ItemImage, collision.GetComponent<Items>().ItemCount);
                }
            }

            Destroy(collision);
        }
    }
}