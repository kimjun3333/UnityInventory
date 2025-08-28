using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlotUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemAbility;
    [SerializeField] private TextMeshProUGUI itemPrice;

    [SerializeField] private Button buyBtn;

    private ItemData itemData;

    public ItemData ItemData
    {
        get { return itemData; }
        set
        {
            itemData = value;
            if (itemData != null)
            {
                itemImage.sprite = itemData.icon;
                itemImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                itemImage.color = new Color(1, 1, 1, 0);
            }
        }
    }
    public void ShowItemData(ItemData item)
    {
        ItemData = item;
        itemName.text = item.displayName;
        string abilityType = item.type == ItemType.Weapon ? "공격력" : "방어력";
        itemAbility.text = $"{abilityType} + {item.ability}";
        itemPrice.text = $"{item.price}G";
    }

    public void BuyItem()
    {
        if(GameManager.Instance.player.gold.CurValue >= ItemData.price)
        {
            GameManager.Instance.player.gold.CurValue -= ItemData.price;
            GameManager.Instance.player.AddItem(itemData);
        }
    }
}
