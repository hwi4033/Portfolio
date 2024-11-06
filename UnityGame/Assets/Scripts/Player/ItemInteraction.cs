using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] GameObject item;

    [SerializeField] string targetTag = "Item";
    [SerializeField] float distance = 2.0f;

    public void DetectItem()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, distance);
        
        foreach (var collision in collisions)
        {
            if (collision.CompareTag(targetTag))
            {
                item = collision.gameObject;

                PopUpManager.Instance.Show(AlarmType.OBTAIN);

                ObtainItem();

                return;
            }
        }

        PopUpManager.Instance.Hide(AlarmType.OBTAIN);
    }

    public void ObtainItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // inventory
            inventory.GetComponent<Inventory>().AddItem(item);

            Destroy(item);
        }
    }
}