using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI abilityText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button equipBtn;
    [SerializeField] private Button unequipBtn;

    private ItemData currentItem;


    public void Show(ItemData item)
    {
        currentItem = item;
        nameText.text = item.displayName;
        string abilityType = item.type == ItemType.Weapon ? "공격력" : "방어력";
        abilityText.text = $"{abilityType} + {item.ability}";
        descriptionText.text = item.description;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClickEquip()
    {
        GameManager.Instance.player.EquipItem(currentItem);
        //Hide();
    }

    public void OnClickUnEquip()
    {
        GameManager.Instance.player.UnEquipItem(currentItem);
        //Hide();
    }
}
