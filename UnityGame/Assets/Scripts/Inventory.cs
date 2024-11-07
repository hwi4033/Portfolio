using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Items> lists;
    [SerializeField] Slot[] slots;

    private void Awake()
    {
        lists.Capacity = 10;
    }

    public void AddItem(Items item)
    {
        lists.Add(item);

        slots[lists.Count - 1].Item = item;

        slots[lists.Count - 1].GetComponent<Slot>().SetSlot(item);
    }
}