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
        lists.Capacity = 20;
    }

    private void Start()
    {
        slots = transform.GetComponentsInChildren<Slot>();
    }
}