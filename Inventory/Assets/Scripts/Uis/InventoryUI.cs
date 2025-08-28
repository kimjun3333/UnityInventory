using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : UIBase
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private ItemDataPanel itemDataPanel;

    [SerializeField] private List<ItemSlotUI> slotList = new();

    public TextMeshProUGUI InvenText;

    private Player player;

    private void Start()
    {
        player = GameManager.Instance.player;
        player.OnInventoryChanged += UpdateUI;
        GenerateSlots(4);
        UpdateUI();
    }

    private void OnDestroy()
    {
        player.OnInventoryChanged -= UpdateUI;
    }

    private void GenerateSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject slotGo = Instantiate(slotPrefab, slotParent);
            ItemSlotUI slotUI = slotGo.GetComponentInChildren<ItemSlotUI>();
            slotUI.SetPanel(itemDataPanel);
            slotList.Add(slotUI);
        }
    }

    public void UpdateUI()
    {
        if(player.items.Count > slotList.Count)
        {
            GenerateSlots(4);
        }

        int i = 0;
        for (; i < player.items.Count && i < slotList.Count; i++)
        {
            slotList[i].ItemData = player.items[i];
        }
        for (; i < slotList.Count; i++)
        {
            slotList[i].ItemData = null;
        }

        InvenText.text = $"º¸À¯ {player.items.Count} / {slotList.Count}";
    }
}
