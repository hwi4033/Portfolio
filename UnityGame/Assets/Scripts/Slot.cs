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
// 상위 객체에서 사용할 스프라이트를 연결할 변수
public Sprite parentSprite;

void Start()
{
// 하위 객체를 가져옵니다.
Transform child = transform.GetChild(0); // 첫 번째 하위 객체로 설정
if (child != null)
{
    // 하위 객체의 SpriteRenderer를 가져옵니다.
    SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
    if (childSpriteRenderer != null)
    {
        // 하위 객체의 SpriteRenderer에 상위 객체의 스프라이트를 설정합니다.
        childSpriteRenderer.sprite = parentSprite;
    }
*/
}
}