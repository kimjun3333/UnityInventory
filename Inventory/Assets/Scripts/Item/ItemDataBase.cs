using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Item/DataBase") ]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> itemLists;
}
