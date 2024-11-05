using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> lists;
    [SerializeField] GameObject slot;

    private void Awake()
    {
        lists.Capacity = 10;
    }

    public void AddItem(GameObject item)
    {
        lists.Add(item);
    }
}