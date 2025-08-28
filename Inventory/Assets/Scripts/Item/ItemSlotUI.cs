using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ItemDataPanel itemDataPanel;
    [SerializeField] private ItemData itemData;
    [SerializeField] private TextMeshProUGUI equipText;
    public ItemData ItemData
    {
        get { return itemData; }
        set
        {
            itemData = value;
            if (itemData != null)
            {
                image.sprite = itemData.icon;
                image.color = new Color(1, 1, 1, 1);
                equipText.text = PlayerHasEquipped(itemData);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void SetPanel(ItemDataPanel panel)
    {
        itemDataPanel = panel;
    }

    public void TogglePanel()
    {
        if (itemData == null) return;

        if(itemDataPanel.gameObject.activeSelf)
        {
            itemDataPanel.Hide();
        }
        else
        {
            itemDataPanel.Show(itemData);
        }
    }

    private string PlayerHasEquipped(ItemData item)
    {
        var player = GameManager.Instance.player;
        if (item.type == ItemType.Weapon && player.equippedWeapon == item)
            return "E";
        if (item.type == ItemType.Armor && player.equippedArmor == item)
            return "E";
        return "";
    }
}
