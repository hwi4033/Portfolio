using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> lists;
    [SerializeField] GameObject slot;

    [SerializeField] int listsCount = 9;

    private void Awake()
    {
        lists.Capacity = 10;
    }

    private void Start()
    {
        for (int i = 0; i < listsCount; i++)
        {
            GameObject clone = Instantiate(slot, transform);

            lists.Add(clone);
        }
    }
}