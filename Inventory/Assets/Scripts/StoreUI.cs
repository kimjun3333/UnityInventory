using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : UIBase
{
    public ItemDataBase itemDataBase;
    [SerializeField] private Transform slotParent;
    [SerializeField] private StoreSlotUI slotPrefab;

    private List<StoreSlotUI> slotList = new();

    private void Start()
    {
        Generateslots();
    }
    private void Generateslots()
    {
        for(int i = 0; i < itemDataBase.itemLists.Count; i++)
        {
            StoreSlotUI slot = Instantiate(slotPrefab, slotParent);
            slot.ShowItemData(itemDataBase.itemLists[i]);
            slotList.Add(slot);
        }
    }
}
