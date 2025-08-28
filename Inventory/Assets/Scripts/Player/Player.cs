using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
    public string className = "Warrior";
    public string playerName = "스파르탄";
    public string description = "대충 설명";

    public ItemData equippedWeapon;
    public ItemData equippedArmor;

    public List<ItemData> items = new();

    public event Action OnInventoryChanged;

    private void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.player = this;
        }
    }
    
    public void EquipItem(ItemData item)
    {
        switch(item.type)
        {
            case ItemType.Weapon:
                if(equippedWeapon != null)
                {
                    UnEquipItem(equippedWeapon);
                }

                equippedWeapon = item;
                break;

            case ItemType.Armor:
                if (equippedArmor != null)
                {
                    UnEquipItem(equippedArmor);
                }

                equippedArmor = item; 
                break;
        }

        ApplyStat();
    }

    public void UnEquipItem(ItemData item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                atk.CurValue -= ReturnWeaponStat();
                equippedWeapon = null;
                break;

            case ItemType.Armor:
                def.CurValue -= ReturnArmorStat();
                equippedArmor = null;
                break;
        }

        ApplyStat();
    }
    private void ApplyStat()
    {
        atk.CurValue += ReturnWeaponStat();
        def.CurValue += ReturnArmorStat();
    }
    private int ReturnWeaponStat()
    {
        return equippedWeapon != null ? equippedWeapon.ability : 0;
    }

    private int ReturnArmorStat()
    {
        return equippedArmor != null ? equippedArmor.ability : 0;
    }

    public void AddItem(ItemData item)
    {
        items.Add(item);
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
        OnInventoryChanged?.Invoke();
    }
}
