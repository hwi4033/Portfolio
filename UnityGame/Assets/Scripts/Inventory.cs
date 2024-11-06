using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> lists;

    private void Awake()
    {
        lists.Capacity = 10;
    }

    public void AddItem(GameObject item)
    {
        lists.Add(item);
        
    }
}