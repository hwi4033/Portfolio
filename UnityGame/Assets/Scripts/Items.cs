using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField] Sprite itemImage;
    [SerializeField] int itemCount;

    public Sprite ItemImage
    {
        get { return itemImage; }
    }

    public int ItemCount
    {
        get { return itemCount; }
    }
}