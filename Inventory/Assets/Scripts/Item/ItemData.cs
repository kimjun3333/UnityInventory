using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemObject")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public int ID;
    public string DisplayName;
    public string Description;
    public Sprite Icon;
}
