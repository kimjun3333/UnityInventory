using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] Image image;

    private ItemData itemData;
    public ItemData ItemData
    {
        get { return itemData; }
        set
        {
            itemData = value;
            if(itemData != null )
            {
                image.sprite = itemData.Icon;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

}
