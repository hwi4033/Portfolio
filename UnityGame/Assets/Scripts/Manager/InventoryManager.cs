using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] bool setInventory = false;

    private void Update()
    {
        SetInventory();
    }

    public void SetInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            setInventory = !setInventory;
        }

        if (setInventory)
        {
            inventory.gameObject.SetActive(setInventory);
        }
        else
        {
            inventory.gameObject.SetActive(setInventory);
        }
    }
}