using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : Inventory
{
    [SerializeField] Items item;
    [SerializeField] Sprite itemImage;
    [SerializeField] Text itemCount;
    private int temp = 0;

    public Items Item
    {
        get { return item; }
    }

    private void Awake()
    {
        itemCount = GetComponent<Text>();
    }

    public void AddItem(Sprite image, int itemCount)
    {
        temp += itemCount;
        
        if (image != null)
        {
            itemImage = image;
        }
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