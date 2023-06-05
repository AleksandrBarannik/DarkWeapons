using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryView : MonoBehaviour
{
    [SerializeField]
    private Image _itemIcon;
    public Image ItemIcon => _itemIcon;

    [SerializeField]
    public TextMeshProUGUI _stackCountTMP;
    
    

    public void SetItem(Item item)
    {
        if (item != null)
        {
            _itemIcon.sprite = item.Icon;
            _stackCountTMP.gameObject.SetActive(true);
            _stackCountTMP.text = $"{item.StackCount}/{item.StackMaxCount}";
        }
        else
        {
            _itemIcon.sprite = null;
            _stackCountTMP.gameObject.SetActive(false);
        }
    }

}
