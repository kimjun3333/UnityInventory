using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : UIBase
{
    public List<ItemData> items;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    [SerializeField] private List<ItemSlotUI> slotList = new();

    public TextMeshProUGUI InvenText;

    private void Awake()
    {
        GenerateSlots(4);
        UpdateSlot();
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            AddItem(items[0]);
        }
    }

    private void GenerateSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject slotGo = Instantiate(slotPrefab, slotParent);
            ItemSlotUI slotUI = slotGo.GetComponentInChildren<ItemSlotUI>();
            slotList.Add(slotUI);
        }
    }

    public void UpdateSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slotList.Count; i++)
        {
            slotList[i].ItemData = items[i];
        }
        for (; i < slotList.Count; i++)
        {
            slotList[i].ItemData = null;
        }
    }

    public void UpdateText()
    {
        InvenText.text = $"º¸À¯ {items.Count} / {slotList.Count}";
    }

    public void AddItem(ItemData item)
    {
        if (items.Count >= slotList.Count)
        {
            GenerateSlots(4);
        }
        items.Add(item);
        UpdateSlot();
        UpdateText();
    }
}
