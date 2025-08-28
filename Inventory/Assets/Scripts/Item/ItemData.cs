using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor
}
[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemObject")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public int ID;
    public string displayName;
    public string description;
    public Sprite icon;
    public int ability;
    public int price;
    public ItemType type;
}
