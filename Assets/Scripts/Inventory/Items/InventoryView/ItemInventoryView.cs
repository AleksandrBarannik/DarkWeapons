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
        _itemIcon.sprite = item.Icon;
    }
    
    public void SetItem(ConsumableItem item, int currenCountInSlot)
    {
        _stackCountTMP.gameObject.SetActive(true);
        _stackCountTMP.text = currenCountInSlot.ToString();
    }

    


    
}
