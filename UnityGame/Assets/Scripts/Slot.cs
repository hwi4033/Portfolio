using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : Inventory
{
    [SerializeField] Items item;
    [SerializeField] Sprite itemImage;
    [SerializeField] Image image;
    [SerializeField] Text itemCount;
    int temp = 0;

    private void Awake()
    {
        itemCount = GetComponent<Text>();
    }

    public Items Item
    {
        set { item = value; }
    }

    public void SetSlot(Items item)
    {
        itemImage = item.ItemImage;
        temp += item.ItemCount;
        // itemCount.text = temp.ToString();
/*
// ���� ��ü���� ����� ��������Ʈ�� ������ ����
public Sprite parentSprite;

void Start()
{
// ���� ��ü�� �����ɴϴ�.
Transform child = transform.GetChild(0); // ù ��° ���� ��ü�� ����
if (child != null)
{
    // ���� ��ü�� SpriteRenderer�� �����ɴϴ�.
    SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
    if (childSpriteRenderer != null)
    {
        // ���� ��ü�� SpriteRenderer�� ���� ��ü�� ��������Ʈ�� �����մϴ�.
        childSpriteRenderer.sprite = parentSprite;
    }
*/
}
}