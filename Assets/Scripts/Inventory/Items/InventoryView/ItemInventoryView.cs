using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryView : MonoBehaviour
{
    [SerializeField]
    private Image _itemIcon;
    public Image ItemIcon => _itemIcon;

    public void SetItem(Item item)
    {
        _itemIcon.sprite = item.Icon;
    }
    
    
}
